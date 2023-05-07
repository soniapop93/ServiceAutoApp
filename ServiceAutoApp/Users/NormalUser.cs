namespace ServiceAutoApp.Users
{
    public class NormalUser : User
    {
        public NormalUser(
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
