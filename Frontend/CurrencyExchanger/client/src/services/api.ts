import axios from 'axios';
import { Currency, CurrencyPrice } from '../types/currency';

const API_BASE_URL = 'http://localhost:5081/api';

export const api = axios.create({
  baseURL: API_BASE_URL,
  timeout: 10000
});

export const fetchCurrencies = async (): Promise<Currency[]> => {
  const response = await api.get('/Currency');
  return response.data;
};

export const fetchCurrencyInfo = async (code: string): Promise<Currency> => {
  try {
    const response = await api.get(`/Currency/${code}`);
    if (!response.data) {
      throw new Error(`Currency ${code} not found`);
    }
    return response.data;
  } catch (error) {
    console.error(`Error fetching currency ${code}:`, error);
    throw new Error(`Failed to fetch currency ${code}`);
  }
};

export const fetchCurrencyPrices = async (
  paymentCurrency: string,
  purchasedCurrency: string,
  fromDateTime: Date
): Promise<CurrencyPrice[]> => {
  try {
    const params = new URLSearchParams({
      PaymentCurrency: paymentCurrency,
      PurchasedCurrency: purchasedCurrency,
      FromDateTime: fromDateTime.toISOString()
    });

    const response = await axios.get(`${API_BASE_URL}/Currency/prices/?${params}`);
    return response.data;
  } catch (error) {
    console.error('API Error:', error);
    throw new Error('Failed to fetch currency prices');
  }
};
