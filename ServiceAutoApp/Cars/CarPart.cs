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
    }
}
