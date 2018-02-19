namespace SmartHotel.Clients.Core.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Crop { get; set; }

        public string RadL { get; set; }

        public string SAP { get; set; }

        public int TotalCount { get; set; }

        public int ProgramCount { get; set; }



        public override string ToString()
        {
            return $"{Name}, {Country}";
        }
    }
}
