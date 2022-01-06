using Neptune.Models;
using System.Collections.Generic;

namespace Neptune.Models
{
    public class Script : Content
    {
        public string type { get; set; }
        public User user { get; set; }
        public virtual ICollection<ScriptParameter> parameter { get; set; }

    }
}