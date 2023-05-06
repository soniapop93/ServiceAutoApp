using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAutoApp.Cars
{
    public class Car
    {
        public int carId { get; set; }
        public int customerId { get; set; }
        public string carNumber { get; set; }
        public string  vinNumber { get; set; }
        public int year { get; set; }
        public int engineCapacity { get; set; }
        public string fuelType { get; set; }
        public string color { get; set; }
        List<CarPart> carParts { get; set; }
        public DateTime registrationDate { get; set; }

        public Car(
            int carId, 
            int customerId, 
            string carNumber, 
            string vinNumber, 
            int year, 
            int engineCapacity, 
            string fuelType, 
            string color, 
            List<CarPart> carParts, 
            DateTime registrationDate)
        {
            this.carId = carId;
            this.customerId = customerId;
            this.carNumber = carNumber;
            this.vinNumber = vinNumber;
            this.year = year;
            this.engineCapacity = engineCapacity;
            this.fuelType = fuelType;
            this.color = color;
            this.carParts = carParts;
            this.registrationDate = registrationDate;
        }
    }
}
