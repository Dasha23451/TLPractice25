import { useState, useEffect } from 'react';
import { fetchCurrencies, fetchCurrencyPrices } from '../services/api';
import { Currency, CurrencyPrice } from '../types/currency';

export const useCurrencyData = (initialPaymentCurrency: string, initialPurchasedCurrency: string) => {
  const [currencies, setCurrencies] = useState<Currency[]>([]);
  const [paymentCurrency, setPaymentCurrency] = useState(initialPaymentCurrency);
  const [purchasedCurrency, setPurchasedCurrency] = useState(initialPurchasedCurrency);
  const [currentPrice, setCurrentPrice] = useState<CurrencyPrice | null>(null);
  const [priceHistory, setPriceHistory] = useState<CurrencyPrice[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const loadData = async () => {
      try {
        setLoading(true);
        const [allCurrencies, prices] = await Promise.all([
          fetchCurrencies(),
          fetchCurrencyPrices(initialPaymentCurrency, initialPurchasedCurrency, new Date(Date.now() - 60000))
        ]);

        setCurrencies(allCurrencies);
        setPriceHistory(prices);
        if (prices.length > 0) {
          setCurrentPrice(prices[prices.length - 1]);
        }
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Unknown error');
      } finally {
        setLoading(false);
      }
    };

    loadData();

    const interval = setInterval(async () => {
      try {
        const prices = await fetchCurrencyPrices(paymentCurrency, purchasedCurrency, new Date(Date.now() - 10000));
        setPriceHistory(prices);
        if (prices.length > 0) {
          setCurrentPrice(prices[prices.length - 1]);
        }
      } catch (err) {
        console.error('Polling error:', err);
      }
    }, 10000);

    return () => clearInterval(interval);
  }, [paymentCurrency, purchasedCurrency]);

  return {
    currencies,
    paymentCurrency,
    setPaymentCurrency,
    purchasedCurrency,
    setPurchasedCurrency,
    currentPrice,
    priceHistory,
    loading,
    error
  };
};
