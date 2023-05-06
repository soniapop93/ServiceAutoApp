using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAutoApp.Users
{
    public class AdminUser : User
    {
        public AdminUser(
            int userId, 
            string username, 
            string password, 
            string firstName, 
            string lastName, 
            string email, 
            string phone, 
            string address, 
            DateTime registeredDate) : base(userId, username, password, firstName, lastName, email, phone, address, registeredDate)
        {
        }
    }
}
