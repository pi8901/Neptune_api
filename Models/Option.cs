using Neptune.Models;
using System.Collections.Generic;

namespace Neptune.Models
{
    public class Option : Content
    {
        public Option()
        {
            this.parameter = new HashSet<Parameter>();
        }

        public virtual ICollection<Parameter> parameter {get; set; }
        public int datatype { get; set; }

        public string value { get; set; }
    }
}