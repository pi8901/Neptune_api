using Neptune.Models;
using System.ComponentModel.DataAnnotations;

namespace Neptune.Models
{
    public class User : Table
    {
        [Key]
        public string username { get; set; }
        public string display_name { get; set; }
        public int permissions { get; set; }
    }
}