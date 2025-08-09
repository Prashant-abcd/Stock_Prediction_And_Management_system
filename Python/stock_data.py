import yfinance as yf
import pandas as pd
from datetime import datetime

# Define the list of stocks with their StockID and StockSymbol
stocks = [
    {"StockID": 1, "StockSymbol": "AAPL"},
    {"StockID": 2, "StockSymbol": "MSFT"},
    {"StockID": 3, "StockSymbol": "AMZN"},
    {"StockID": 4, "StockSymbol": "NVDA"},
    {"StockID": 5, "StockSymbol": "TSLA"},
    {"StockID": 6, "StockSymbol": "GOOGL"},
    {"StockID": 7, "StockSymbol": "GOOG"},
    {"StockID": 8, "StockSymbol": "META"},
    {"StockID": 9, "StockSymbol": "BRK-B"},
    {"StockID": 10, "StockSymbol": "V"},
    {"StockID": 11, "StockSymbol": "JNJ"},
    {"StockID": 12, "StockSymbol": "WMT"},
    {"StockID": 13, "StockSymbol": "XOM"},
    {"StockID": 14, "StockSymbol": "PG"},
    {"StockID": 15, "StockSymbol": "UNH"},
    {"StockID": 16, "StockSymbol": "JPM"},
    {"StockID": 17, "StockSymbol": "005930.KS"},  # Samsung (Korean stock)
    {"StockID": 18, "StockSymbol": "TM"},
    {"StockID": 19, "StockSymbol": "NSRGY"},  # Nestle (OTC market)
    {"StockID": 20, "StockSymbol": "KO"},
]

# Function to download and process stock data
def download_and_process_stock_data(stock_symbol, stock_id, start_date="2010-01-01", end_date=datetime.today().strftime('%Y-%m-%d')):
    try:
        # Download historical data using yfinance
        stock_data = yf.download(stock_symbol, start=start_date, end=end_date)
        
        # Check if data is empty
        if stock_data.empty:
            print(f"❌ No data for {stock_symbol}.")
            return None  # Return None if no data

        # Add StockID and adjust column names
        stock_data.reset_index(inplace=True)
        stock_data["StockID"] = stock_id
        stock_data.rename(columns={
            "Date": "TradeDate",
            "Open": "OpenPrice",
            "High": "HighPrice",
            "Low": "LowPrice",
            "Close": "ClosePrice",
            "Adj Close": "AdjClosePrice",
            "Volume": "Volume"
        }, inplace=True)

        # If AdjClosePrice is not available, fill it with ClosePrice
        if "AdjClosePrice" not in stock_data.columns:
            stock_data["AdjClosePrice"] = stock_data["ClosePrice"]

        # Select only the required columns
        stock_data = stock_data[["StockID", "TradeDate", "OpenPrice", "HighPrice", "LowPrice", "ClosePrice", "AdjClosePrice", "Volume"]]
        
        return stock_data
    except Exception as e:
        print(f"Error downloading data for {stock_symbol}: {e}")
        return None

# Loop through each stock and download data
for stock in stocks:
    print(f"Downloading data for {stock['StockSymbol']} (StockID: {stock['StockID']})...")
    stock_data = download_and_process_stock_data(stock["StockSymbol"], stock["StockID"])
    
    # If data is returned, save it to a separate CSV file
    if stock_data is not None:
        csv_filename = f"{stock['StockSymbol']}_price_data.csv"
        stock_data.to_csv(csv_filename, index=False, date_format="%Y-%m-%d")
        print(f"Data for {stock['StockSymbol']} saved to {csv_filename}.")