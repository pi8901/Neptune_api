using Neptune.Models;
using System.Collections.Generic;

namespace Neptune.Models
{
    public class Script : Content
    {

        public Script()
        {
            this.parameter = new HashSet<Parameter>();
        }

        public virtual ICollection<Parameter> parameter { get; set; }
        public string type { get; set; }
        public User user { get; set; }

    }
}