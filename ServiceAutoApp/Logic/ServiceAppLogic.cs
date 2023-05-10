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
                    //TODO: implement logic for admin user
                }
                else
                {
                    //TODO: implement logic for normal user
                }
            }
        }
    }
}
