CREATE OR REPLACE PROCEDURE InsertPriceData (
    p_StockID IN INT,
    p_TradeDate IN DATE,
    p_OpenPrice IN DECIMAL,
    p_HighPrice IN DECIMAL,
    p_LowPrice IN DECIMAL,
    p_ClosePrice IN DECIMAL,
    p_AdjClosePrice IN DECIMAL,  -- Added parameter for adjusted close price
    p_Volume IN NUMBER
) AS
BEGIN
    INSERT INTO PriceData (StockID, TradeDate, OpenPrice, HighPrice, LowPrice, ClosePrice, AdjClosePrice, Volume)
    VALUES (p_StockID, p_TradeDate, p_OpenPrice, p_HighPrice, p_LowPrice, p_ClosePrice, p_AdjClosePrice, p_Volume);
    COMMIT;  -- Commit the transaction
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;  -- Rollback in case of error
        RAISE;      -- Raise the error for further handling
END InsertPriceData;
/