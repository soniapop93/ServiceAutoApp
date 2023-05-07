using ServiceAutoApp.Cars;

namespace ServiceAutoApp.Customers
{
    public class Customer
    {
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string lastName {get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public List<Car> cars { get; set; }
        public DateTime registredDate { get; set; }

        public Customer(
            int customerId, 
            string firstName, 
            string lastName, 
            string phone, 
            string address, 
            string email, 
            List<Car> cars, 
            DateTime registredDate)
        {
            this.customerId = customerId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.address = address;
            this.email = email;
            this.cars = cars;
            this.registredDate = registredDate;
        }
    }
}
