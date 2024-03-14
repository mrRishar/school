using Store.Application.Enums;

namespace Store.Application.Models
{
    public class Phone
    {
        public string Model { get; set; }
        public uint Height { get; set; }
        public uint Width { get; set; }
        public PhoneColor Color { get; set; }
        public double Price { get; set; }
        public uint Id { get; set; }
    }
}