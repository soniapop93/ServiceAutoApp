﻿using System.Data.SQLite;

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
    }
}