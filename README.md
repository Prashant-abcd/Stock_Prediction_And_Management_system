# Stock_Prediction_And_Management_system

This project is a **stoct prediction and management system** developed for our Database Systems coursework.  
It enables users to track stock prices, view historical trends, and forecast future prices using the **Simple Exponential Smoothing (SES)** algorithm.

## 📌 Features
- **User Authentication** — Secure login via C# WinForms.
- **Stock Tracking** — View current and historical prices of 20 companies.
- **Stock Prediction** — Forecast future prices using SES.
- **Automated Updates** — Python script fetches daily stock data from Alpha Vantage API.
- **Data Visualization** — Charts and graphs for better analysis.

## 🛠 Technology Stack
- **Database:** Oracle SQL\*Plus with an 8-table normalized schema.
- **Backend Automation:** Python for daily data fetching and insertion.
- **Frontend:** C# WinForms for a desktop UI.
- **Stored Procedures:** PL/SQL for automated data insertion.

## 🗄 Database Highlights
- **Stock Table:** Contains 20 companies with stock symbols.
- **StockPrice Table:** Stores daily data since 2010.
- **Automation:** Python script + PL/SQL procedure inserts new prices daily.

## 📈 About SES Prediction
Simple Exponential Smoothing is a time-series forecasting method that applies exponentially decreasing weights to past observations, giving more importance to recent data. This helps generate short-term forecasts for stock prices.

By combining database design, UI development, automation, and the SES forecasting method, this project demonstrates how relational databases can power a complete financial tracking and prediction system.

