using Neptune.Models;
using System.ComponentModel.DataAnnotations;

namespace Neptune.Models
{
    public class Table
    {
        public bool archived { get; set; }
        [Timestamp]
        public byte[] created { get; set; }
        [Timestamp]
        public byte[] updated { get; set; }

    }
}