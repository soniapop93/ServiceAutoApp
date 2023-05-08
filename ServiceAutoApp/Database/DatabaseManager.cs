using System.Data.SQLite;
using ServiceAutoApp.Customers;
using ServiceAutoApp.Users;
using ServiceAutoApp.Customers;

namespace ServiceAutoApp.Database
{
    public class DatabaseManager
    {
        private SQLiteConnection sqLiteConnection;

        public DatabaseManager()
        {
            generateDB("C:\\Users\\" + System.Environment.UserName + "\\Desktop", "ServiceAutoDB");
        }
        private void generateDB(string path, string fileName)
        {
            string fileNamePath = path + @"\" + fileName + ".db";
            createConnection(fileNamePath);

            Console.WriteLine("Database is created successfully");
            createTableUsers();
            createTableCustomers();
            createTableCars();
        }

        private void createConnection(string fileNamePath)
        {
            string strConnection = String.Format("Data Source={0};Version=3;New=True;Compress=True;", fileNamePath);
            sqLiteConnection = new SQLiteConnection(strConnection);
        }

        public void createTableUsers()
        {
            string strSql = "CREATE TABLE IF NOT EXISTS Users " +
                "(id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "username TEXT, " +
                "password TEXT, " +
                "firstName TEXT, " +
                "lastName TEXT, " +
                "email TEXT, " +
                "phone TEXT, " +
                "address TEXT, " +
                "registredDate TEXT, " +
                "admin TEXT);";

            sqLiteConnection.Open();
            SQLiteCommand sqLiteCommand = sqLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = strSql;
            sqLiteCommand.ExecuteNonQuery();
            sqLiteConnection.Close();
        }

        public void createTableCustomers()
        {

            string strSql = "CREATE TABLE IF NOT EXISTS Customers " +
                "(id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "firstName TEXT, " +
                "lastName TEXT, " +
                "phone TEXT, " +
                "address TEXT, " +
                "email TEXT, " +
                "registredDate TEXT);";

            sqLiteConnection.Open();
            SQLiteCommand sqLiteCommand = sqLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = strSql;
            sqLiteCommand.ExecuteNonQuery();
            sqLiteConnection.Close();
        }

        public void createTableCars()
        {
            string strSql = "CREATE TABLE IF NOT EXISTS Cars " +
                "(id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "customerID INTEGER, " +
                "carNumber TEXT, " +
                "vinNumber TEXT, " +
                "year INTEGER, " +
                "engineCapacity INTEGER, " +
                "fuelType TEXT, " +
                "color TEXT, " +
                "registredDate TEXT);";

            sqLiteConnection.Open();
            SQLiteCommand sqLiteCommand = sqLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = strSql;
            sqLiteCommand.ExecuteNonQuery();
            sqLiteConnection.Close();
        }

        public void createTableCarParts()
        {
            string strSql = "CREATE TABLE IF NOT EXISTS CarParts " +
                "(id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "carID INTEGER, " +
                "status TEXT, " +
                "carPartName TEXT, " +
                "carPartDescription TEXT, " +
                "registredDate TEXT, " +
                "price INTEGER);";

            sqLiteConnection.Open();
            SQLiteCommand sqLiteCommand = sqLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = strSql;
            sqLiteCommand.ExecuteNonQuery();
            sqLiteConnection.Close();
        }

        public void insertDataUsers(User user)
        {
            string strSql = "INSERT INTO Users " +
                "(username, " +
                "password, " +
                "firstName, " +
                "lastName, " +
                "email, " +
                "phone, " +
                "address, " +
                "registredDate, " +
                "admin) VALUES ('" + 
                user.username + "','" + 
                user.password + "','" + 
                user.firstName + "','" + 
                user.lastName + "','" + 
                user.email + "','" + 
                user.phone + "','" +
                user.address + "','" + 
                user.registeredDate + "','" + 
                user.adminUser.ToString() + "');";

            sqLiteConnection.Open();
            SQLiteCommand sqLiteCommand = sqLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = strSql;
            sqLiteCommand.ExecuteNonQuery();
            sqLiteConnection.Close();
        }

        public void insertDataCustomers(Customer customer)
        {
            string strSql = "INSERT INTO Customers " +
                "(firstName, " +
                "lastName, " +
                "phone, " +
                "address, " +
                "email, " +
                "registredDate) VALUES ('" +
                customer.firstName + "','" +
                customer.lastName + "','" +
                customer.phone + "','" +
                customer.address + "','" +
                customer.email + "','" +
                customer.registredDate.ToString() + "');";

            sqLiteConnection.Open();
            SQLiteCommand sqLiteCommand = sqLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = strSql;
            sqLiteCommand.ExecuteNonQuery();
            sqLiteConnection.Close();
        }
    }
}
