namespace ServiceAutoApp.Cars
{
    public class CarPart
    {
        public int carPartId { get; set; }
        public int carId { get; set; }
        public string status { get; set; }
        public string carPartName { get; set; }
        public string carPartDescription { get; set; }
        public DateTime registreationDate { get; set; }
        public int price { get; set; }

        public CarPart(
            int carPartId, 
            int carId, 
            string status, 
            string carPartName, 
            string carPartDescription, 
            DateTime registreationDate, 
            int price)
        {
            this.carPartId = carPartId;
            this.carId = carId;
            this.status = status;
            this.carPartName = carPartName;
            this.carPartDescription = carPartDescription;
            this.registreationDate = registreationDate;
            this.price = price;
        }
    }
}
