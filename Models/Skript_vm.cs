using Neptune.Models;
using System.Collections.Generic;

namespace Neptune.Models
{
    public class Script_vm 
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public User user { get; set; }
        public virtual ICollection<Parameter> parameter_available { get; set; }
        public virtual ICollection<Parameter> parameter_implemented { get; set; }
    }
}