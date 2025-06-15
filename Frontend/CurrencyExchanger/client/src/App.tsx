import { useState } from 'react';
import { useCurrencyData } from './hooks/useCurrencyData';
import CurrencyConverter from '../src/components/CurrencyConverter/CurrencyConverter';
import Loader from '../src/components/Loader/Loader';
import ErrorDisplay from '../src/components/ErrorDisplay/ErrorDisplay';
import './App.css';

function App() {
  const [initialPaymentCurrency] = useState('PLN');
  const [initialPurchasedCurrency] = useState('CAD');

  const {
    currencies,
    paymentCurrency,
    setPaymentCurrency,
    purchasedCurrency,
    setPurchasedCurrency,
    currentPrice,
    loading,
    error
  } = useCurrencyData(initialPaymentCurrency, initialPurchasedCurrency);

  const handleRetry = () => {
    window.location.reload();
  };

  if (loading && currencies.length === 0) {
    return <Loader />;
  }

  if (error) {
    return <ErrorDisplay error={error} onRetry={handleRetry} />;
  }

  return (
    <div className="app">
      <h1>Currency Exchanger</h1>
      <CurrencyConverter
        currencies={currencies}
        paymentCurrency={paymentCurrency}
        setPaymentCurrency={setPaymentCurrency}
        purchasedCurrency={purchasedCurrency}
        setPurchasedCurrency={setPurchasedCurrency}
        currentPrice={currentPrice}
      />
    </div>
  );
}

export default App;
