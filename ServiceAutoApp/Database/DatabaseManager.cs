using System.Data.SQLite;
using ServiceAutoApp.Customers;
using ServiceAutoApp.Users;
using ServiceAutoApp.Customers;
using ServiceAutoApp.Cars;

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

            insertDataInDB(strSql);
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

            insertDataInDB(strSql);
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

            insertDataInDB(strSql);
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

            insertDataInDB(strSql);
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

            insertDataInDB(strSql);
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

            insertDataInDB(strSql);
        }

        public void insertDataCarParts(CarPart carPart)
        {
            string strSql = "INSERT INTO CarParts " +
                "(carID, " +
                "status, " +
                "carPartName, " +
                "carPartDescription, " +
                "registredDate, " +
                "price) VALUES (" + 
                carPart.carId + ",'" + 
                carPart.status + "','" + 
                carPart.carPartName + "','" + 
                carPart.carPartDescription + "','" + 
                carPart.registreationDate + "'," + 
                carPart.price + ");";

            insertDataInDB(strSql);
        }

        private void insertDataInDB(string strSql)
        {
            sqLiteConnection.Open();
            SQLiteCommand sqLiteCommand = sqLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = strSql;
            sqLiteCommand.ExecuteNonQuery();
            sqLiteConnection.Close();
        }

        public User getUser(string username, string password)
        {
            sqLiteConnection.Open();
            SQLiteCommand sqLiteCommand = sqLiteConnection.CreateCommand();

            string strData = "SELECT * FROM Users WHERE username = " + username + ";";
            sqLiteCommand.CommandText = strData;
            SQLiteDataReader allDBdata = sqLiteCommand.ExecuteReader();

            User user = checkUser(allDBdata, password);

            allDBdata.Close();
            sqLiteConnection.Close();

            return user;
        }

        private User checkUser(SQLiteDataReader allDBdata, string password)
        {
            while (allDBdata.Read())
            {
                if (password.Equals(allDBdata[3].ToString()) {
                    User user = new User(
                        Int32.Parse(allDBdata[0].ToString()), 
                        allDBdata[1].ToString(), 
                        allDBdata[2].ToString(), 
                        allDBdata[3].ToString(), 
                        allDBdata[4].ToString(),
                        allDBdata[5].ToString(), 
                        allDBdata[6].ToString(), 
                        allDBdata[7].ToString(), 
                        DateTime.Parse(allDBdata[8].ToString()), 
                        Boolean.Parse(allDBdata[8].ToString()));

                    return user;
                }
            }
            return null;
        }

        public void updateUserByUsername(string username, string field, string newInfo)
        {
            string strSql = "UPDATE Users Set " + field + " = '" + newInfo + "' WHERE username = '" + username + "';";

            insertDataInDB(strSql);
        }
    }
}
