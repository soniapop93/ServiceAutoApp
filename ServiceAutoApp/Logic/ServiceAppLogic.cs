﻿using ServiceAutoApp.Database;
using ServiceAutoApp.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAutoApp.Logic
{
    public class ServiceAppLogic
    {
        UserInput userInput = new UserInput();
        DatabaseManager databaseManager = new DatabaseManager();
        
        public void authUser()
        {
            Console.WriteLine("Username: ");
            string inputUsername = userInput.getUserInput();

            Console.WriteLine("Password: ");
            string inputPassword = userInput.getUserInput();

            User user = databaseManager.getUser(inputUsername, inputPassword);

            if(user != null)
            {
                bool adminUser = user.adminUser;
                Console.WriteLine("Login successfull as " + (adminUser ? "ADMIN" : "NORMAL") + " user");

                if (adminUser)
                {
                    string optionMenu = "Option menu: " +
                        "1 - Edit user \n" +
                        "2 - Delete user \n" +
                        "3 - Add new customer \n" +
                        "4 - Delete customer \n" +
                        "5 - Add new car \n" +
                        "6 - Delete car \n" +
                        "7 - Service request \n" +
                        "8 - EXIT";
                    
                    Console.WriteLine(optionMenu);

                    string selectedOption = userInput.getUserInput();
                    
                    switch (selectedOption)
                    {
                        default:
                            break;
                        case "1":
                            Console.WriteLine("You have selected option: 1 - Edit user");
                            Console.WriteLine("Please select how you want to search the user by: \n" +
                                "1 - Username \n" +
                                "2 - User ID");

                            string optionField = userInput.getUserInput();
                            switch (optionField)
                            {
                                default:
                                    break;
                                case "1":
                                    Console.WriteLine("Please add the username: ");
                                    string usernameInputToUpdate = userInput.getUserInput();

                                    Console.WriteLine("Fields available to edit, please choose one from: \n" +
                                        "1 - Username \n" +
                                        "2 - Password \n" +
                                        "3 - First Name \n" +
                                        "4 - Last Name\n" +
                                        "5 - Email \n" +
                                        "6 - Phone \n" +
                                        "7 - Address \n" +
                                        "8 - Admin");

                                    string optionToEdit = userInput.getUserInput();

                                    string field = switchEditUserByAdmin(optionToEdit);

                                    if (!String.IsNullOrEmpty(field))
                                    {
                                        Console.WriteLine("You have selected option: " + optionField + "\nPlease add the new information: ");
                                        string newInfo = userInput.getUserInput();
                                        databaseManager.updateUserByUsername(usernameInputToUpdate, field, newInfo);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No correct option selected");
                                    }

                                    


                                    break;
                                case "2":
                                    break;
                            }

                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "6":
                            break;
                        case "7":
                            break;
                        case "8":
                            break;
                    }

                    //TODO: implement logic for admin user
                }
                else
                {
                    string optionMenu = "Option menu: " +
                        "1 - Add new customer \n" +
                        "2 - Add new car \n" +
                        "3 - Service request \n" +
                        "4 - EXIT";

                    Console.WriteLine(optionMenu);

                    //TODO: implement logic for normal user
                }
            }
        }

        private string switchEditUserByAdmin(string option)
        {
            string field = "";

            switch (option)
            {
                default:
                    field = "";
                    break;
                case "1":
                    field = "username";
                    break;
                case "2":
                    field = "password";
                    break;
                case "3":
                    field = "firstName";
                    break;
                case "4":
                    field = "lastName";
                    break;
                case "5":
                    field = "email";
                    break;
                case "6":
                    field = "phone";
                    break;
                case "7":
                    field = "address";
                    break;
                case "8":
                    field = "admin";
                    break;
            }
            return field;
        }
    }
}
