import { useState } from 'react';
import CurrencyInfo from '../CurrencyInfo/CurrencyInfo';
import './CurrencyConverter.css';
import { Currency, CurrencyPrice } from '../../types/currency';

interface CurrencyConverterProps {
  currencies: Currency[];
  paymentCurrency: string;
  setPaymentCurrency: (currency: string) => void;
  purchasedCurrency: string;
  setPurchasedCurrency: (currency: string) => void;
  currentPrice: CurrencyPrice | null;
}

const CurrencyConverter = ({
  currencies,
  paymentCurrency,
  setPaymentCurrency,
  purchasedCurrency,
  setPurchasedCurrency,
  currentPrice
}: CurrencyConverterProps) => {
  const [showInfo, setShowInfo] = useState(false);

  return (
    <div className="card currency-converter">
      <div className="converter-header">
        <h2>
          {paymentCurrency} / {purchasedCurrency}
        </h2>
      </div>

      <div className="currency-selectors">
        <select value={paymentCurrency} onChange={(e) => setPaymentCurrency(e.target.value)}>
          {currencies.map((currency) => (
            <option key={`from-${currency.Code}`} value={currency.Code}>
              {currency.Name} ({currency.Code})
            </option>
          ))}
        </select>

        <span>to</span>

        <select value={purchasedCurrency} onChange={(e) => setPurchasedCurrency(e.target.value)}>
          {currencies.map((currency) => (
            <option key={`to-${currency.Code}`} value={currency.Code}>
              {currency.Name} ({currency.Code})
            </option>
          ))}
        </select>
      </div>

      {currentPrice && (
        <div className="currency-rate">
          <p>
            1 {paymentCurrency} is {currentPrice.Price.toFixed(4)} {purchasedCurrency}
          </p>
          <p>{new Date(currentPrice.DateTime).toLocaleString()}</p>
          <div className="rate-table">
            <table>
              <tbody>
                <tr>
                  <td>1</td>
                  <td>{paymentCurrency}</td>
                </tr>
                <tr>
                  <td>{currentPrice.Price.toFixed(4)}</td>
                  <td>{purchasedCurrency}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      )}

      <button className="more-info-btn" onClick={() => setShowInfo(!showInfo)}>
        More about {paymentCurrency}/{purchasedCurrency}
      </button>

      {showInfo && <CurrencyInfo paymentCurrency={paymentCurrency} purchasedCurrency={purchasedCurrency} />}
    </div>
  );
};

export default CurrencyConverter;
