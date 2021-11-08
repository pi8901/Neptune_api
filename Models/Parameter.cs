using Neptune.Models;
using System.Collections.Generic;

namespace Neptune.Models
{
    public class Parameter : Content
    {
        public Parameter()
        {
            this.scripts = new HashSet<Script>();
            this.parameter = new HashSet<Parameter>();
            this.options = new HashSet<Option>();
        }

        public virtual ICollection<Script> scripts { get; set; }
        public virtual ICollection<Parameter> parameter { get; set; }
        public bool implemented {get; set; }
        public virtual ICollection<Option> options { get; set; }
    }

    public class ParameterViewModel
    {
        public int Id {get; set; }
    }
}