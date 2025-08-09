LOAD DATA
INFILE 'C:\Users\Prashant\Desktop\PythonStockData\CSVFiles\combined_price_data.csv'  
INTO TABLE PriceData
FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '"'
(StockID, TradeDate "TO_DATE(:TradeDate, 'YYYY-MM-DD')", OpenPrice, HighPrice, LowPrice, ClosePrice, AdjClosePrice, Volume)