using Neptune.Models;

namespace Neptune.Models
{
    public class Content : Table
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }

    }
}