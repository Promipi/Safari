namespace BACKEND.Models
{
    public class Evento
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string NameType { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Price { get; set; }

        public string Description { get; set; } 

        public string Image { get; set; }

    }
}
