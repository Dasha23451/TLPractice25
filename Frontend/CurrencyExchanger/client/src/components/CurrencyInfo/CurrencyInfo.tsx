import { useEffect, useState } from 'react';
import { fetchCurrencyInfo } from '../../services/api';

interface CurrencyInfoProps {
  paymentCurrency: string;
  purchasedCurrency: string;
}

interface Currency {
  Code: string;
  Name: string;
  Description: string;
  Symbol: string;
}

const CurrencyInfo = ({ paymentCurrency, purchasedCurrency }: CurrencyInfoProps) => {
  const [paymentInfo, setPaymentInfo] = useState<Currency | null>(null);
  const [purchasedInfo, setPurchasedInfo] = useState<Currency | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const loadCurrencyInfo = async () => {
      try {
        setLoading(true);
        const [paymentData, purchasedData] = await Promise.all([
          fetchCurrencyInfo(paymentCurrency),
          fetchCurrencyInfo(purchasedCurrency)
        ]);
        setPaymentInfo(paymentData);
        setPurchasedInfo(purchasedData);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Unknown error');
      } finally {
        setLoading(false);
      }
    };

    loadCurrencyInfo();
  }, [paymentCurrency, purchasedCurrency]);

  if (loading) return <div>Loading currency info...</div>;
  if (error) return <div>Error loading currency info: {error}</div>;

  return (
    <div className="currency-info">
      <div className="currency-description">
        <h3>
          {paymentInfo?.Name} - {paymentCurrency} - {paymentInfo?.Symbol}
        </h3>
        <p>{paymentInfo?.Description}</p>
      </div>
      <div className="currency-description">
        <h3>
          {purchasedInfo?.Name} - {purchasedCurrency} - {purchasedInfo?.Symbol}
        </h3>
        <p>{purchasedInfo?.Description}</p>
      </div>
    </div>
  );
};

export default CurrencyInfo;
