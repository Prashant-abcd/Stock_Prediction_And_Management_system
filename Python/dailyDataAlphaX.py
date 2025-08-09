import requests
import cx_Oracle
import time
from datetime import datetime


API_KEY = "your_api_key"

# List of stocks with StockID and StockSymbol
stocks = [
    {"StockID": 1, "StockSymbol": "AAPL"},
    {"StockID": 2, "StockSymbol": "MSFT"},
    {"StockID": 3, "StockSymbol": "AMZN"},
    {"StockID": 4, "StockSymbol": "NVDA"},
    {"StockID": 5, "StockSymbol": "TSLA"},
    {"StockID": 6, "StockSymbol": "GOOGL"},
    {"StockID": 7, "StockSymbol": "GOOG"},
    {"StockID": 8, "StockSymbol": "META"},
    {"StockID": 9, "StockSymbol": "BRK.B"},  # Alpha Vantage uses "BRK.B" format
    {"StockID": 10, "StockSymbol": "V"},
    {"StockID": 11, "StockSymbol": "JNJ"},
    {"StockID": 12, "StockSymbol": "WMT"},
    {"StockID": 13, "StockSymbol": "XOM"},
    {"StockID": 14, "StockSymbol": "PG"},
    {"StockID": 15, "StockSymbol": "UNH"},
    {"StockID": 16, "StockSymbol": "JPM"},
    {"StockID": 17, "StockSymbol": "005930.KQ"},  # Samsung Korea
    {"StockID": 18, "StockSymbol": "TM"},
    {"StockID": 19, "StockSymbol": "NSRGY"},  # Nestle
    {"StockID": 20, "StockSymbol": "KO"},
]

# Function to insert data into Oracle database
def insert_data_to_db(stock_id, trade_date, open_price, high_price, low_price, close_price, adj_close_price, volume):
    cursor = None  # Initialize cursor to None
    try:
        # Connect to Oracle database (update with your connection details)
        connection = cx_Oracle.connect('system', 'Prashant11', 'localhost:1521/FREE')
        cursor = connection.cursor()

        # Call PL/SQL procedure to insert data
        cursor.callproc('InsertPriceData', [
            stock_id,                
            trade_date,             
            open_price,             
            high_price,             
            low_price,              
            close_price,            
            adj_close_price,        
            volume                  
        ])
        connection.commit()

        print(f"✅ Data inserted for StockID {stock_id} on {trade_date}")
    except cx_Oracle.DatabaseError as e:
        print(f"❌ Database Error: {e}")
    finally:
        if cursor is not None:
            cursor.close()  # Close cursor only if it was created
        if connection is not None:
            connection.close()  # Close connection only if it was created

# Function to fetch and insert stock data from Alpha Vantage
def fetch_and_store_data(stock_symbol, stock_id):
    url = f"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={stock_symbol}&apikey={API_KEY}&outputsize=compact"
    
    try:
        response = requests.get(url)
        data = response.json()

        # Check for errors
        if "Time Series (Daily)" not in data:
            print(f"❌ Error for {stock_symbol}: {data.get('Note', 'Unknown error')}")
            return

        # Get the most recent price data
        latest_timestamp = max(data["Time Series (Daily)"].keys())
        latest_data = data["Time Series (Daily)"][latest_timestamp]

        # Extract and convert values
        trade_date = datetime.strptime(latest_timestamp, "%Y-%m-%d").date()
        open_price = float(latest_data["1. open"])
        high_price = float(latest_data["2. high"])
        low_price = float(latest_data["3. low"])
        close_price = float(latest_data["4. close"])
        volume = int(latest_data["5. volume"])
        adj_close_price = float(latest_data.get("6. adjusted close", close_price))  # Fetch adjusted close price

        # Insert data into the database
        insert_data_to_db(stock_id, trade_date, open_price, high_price, low_price, close_price, adj_close_price, volume)

    except requests.exceptions.RequestException as e:
        print(f"❌ Request Error for {stock_symbol}: {e}")
    except Exception as e:
        print(f"❌ An error occurred while fetching data for {stock_symbol}: {e}")

# Main execution loop
if __name__ == "__main__":
    for stock in stocks:
        fetch_and_store_data(stock["StockSymbol"], stock["StockID"])
        time.sleep(12)  # To avoid hitting the API rate limit