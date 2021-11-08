using Neptune.Models;
using System.ComponentModel.DataAnnotations;

namespace Neptune.Models
{
    public class Table
    {
        public bool archived { get; set; }
        
        public string created { get; set; }
        
        public string updated { get; set; }

    }
}