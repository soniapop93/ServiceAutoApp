using ServiceAutoApp.Database;
using ServiceAutoApp.Users;
using System;
using System.Collections.Generic;
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
    }
}
