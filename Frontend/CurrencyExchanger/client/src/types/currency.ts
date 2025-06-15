export interface Currency {
  Code: string;
  Name: string;
  Description: string;
  Symbol: string;
  MinPrice?: number;
  MaxPrice?: number;
}

export interface CurrencyPrice {
  Price: number;
  DateTime: string;
  CurrencyCode: string;
  Currency?: Currency;
}
