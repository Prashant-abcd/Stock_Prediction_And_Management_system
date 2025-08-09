import pandas as pd
import glob

# Path to your CSV files
path = 'C:/Users/Prashant/Desktop/PythonStockData/CSVFiles/'  # Ensure the path ends with a slash
all_files = glob.glob(path + "*.csv")  # Use forward slash for the wildcard

print("CSV files found:", all_files)  # Debugging line to check found files

# Initialize an empty list to hold DataFrames
dataframes = []

# Loop through each file
for file in all_files:
    print(f"Reading file: {file}")  # Debugging line
    try:
        # Read the file and skip the header
        df = pd.read_csv(file, header=0)  # Skip the header
        
        # Check if StockID exists and handle non-finite values
        if 'StockID' in df.columns:
            # Drop rows where StockID is NaN or infinite
            df = df[pd.to_numeric(df['StockID'], errors='coerce').notnull()]  # Keep only valid StockID rows
            df['StockID'] = df['StockID'].astype(int)  # Convert to integer
            print(f"Converted StockID to integer for {file}.")  # Debugging line
        
        dataframes.append(df)
        print(f"Successfully read {file}, shape: {df.shape}")  # Debugging line
    except Exception as e:
        print(f"Error reading {file}: {e}")  # Print any errors encountered

# Check if dataframes list is empty
if not dataframes:
    print("No dataframes to concatenate.")  # Debugging line
else:
    # Combine all DataFrames into one
    combined_data = pd.concat(dataframes, ignore_index=True)

    # Save the combined DataFrame to a new CSV file
    combined_data.to_csv('combined_price_data.csv', index=False, header=False)  # No header in the output
    print("Combined data saved to 'combined_price_data.csv'.")