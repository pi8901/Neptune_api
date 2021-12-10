using Neptune.Models;
using System.Collections.Generic;

namespace Neptune.Models
{
    public class Parameter : Content
    {
        public Parameter()
        {
            this.scripts = new HashSet<Script>();
            this.parameter_child = new HashSet<Parameter>();
            this.parameter_parent = new HashSet<Parameter>();
            this.options = new HashSet<Option>();
        }

        public virtual ICollection<Script> scripts { get; set; }
        public virtual ICollection<Parameter> parameter_child { get; set; }
        public virtual ICollection<Parameter> parameter_parent { get; set; }
        public bool implemented {get; set; }
        public virtual ICollection<Option> options { get; set; }
    }
}