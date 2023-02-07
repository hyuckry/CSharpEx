# Connection Classes
- Connection
- Transaction
- Command -> SQL command to send to database
- DataAdapter -> Fill a DataSet/DataTable with data
- DataReader -> A fast, forward-only cursor to read data


# Disconnected Classes
- DataSet
- DataTable
- DataView
- DataRow
- DataColumn

# Builder Classes
- ConnectionStringBuilder -> Create or break apart a connection string
- CommandBuilder -> Create an insert, update or delete command


- Close when done
- Dispose of unmanaged resources


https://www.connectionstrings.com


Microsoft.Data.SqlClient 는 System.Data.SqlClient 새버전임 차이점은 아래 참조
https://github.com/dotnet/SqlClient/blob/main/porting-cheat-sheet.md