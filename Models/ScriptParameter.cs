namespace Neptune.Models
{
    public class ScriptParameter : Table
    {
        public int Id { get; set; }
        public bool implemented{ get; set; }
        public virtual Script script{ get; set; }
        public virtual Parameter parameter{ get; set; }

    }
}