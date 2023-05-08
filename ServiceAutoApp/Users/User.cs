namespace ServiceAutoApp.Users
{
    public class User
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime registeredDate { get; set; }
        public bool adminUser { get; set; }

        public User(
            int userId, 
            string username, 
            string password, 
            string firstName, 
            string lastName, 
            string email, 
            string phone, 
            string address, 
            DateTime registeredDate, 
            bool adminUser)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.registeredDate = registeredDate;
            this.adminUser = adminUser;
        }
    }
}
