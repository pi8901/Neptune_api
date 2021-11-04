using Neptune.Models;
using Neptune.Data;

namespace Neptune
{
    public class mock_data
    {
        public mock_data()
        {
            DatabaseDbContext context = new DatabaseDbContext();
            DateTime d = DateTime.Now;
            Console.Write(d);
            Parameter[] x = new Parameter[];
            Option option_a = new Option { archived = false, updated = d,
             created = d, Id = 1, title = "option_a", description = "This is option_a", datatype = 1, parameter = x  };
            context.Add(option_a);
            context.SaveChanges();
        }
    }

}