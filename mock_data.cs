using System;
using System.Text;
using Neptune.Models;
using Neptune.Data;
using System.Collections.Generic;

namespace Neptune
{
    public class mock_data
    {
        public mock_data()
        {
            DatabaseDbContext context = new DatabaseDbContext();
            var date = DateTime.Now.ToString();

            User user_1 = new User {username = "arne", display_name = "Arne Geiken", permissions = 1, archived = false, created = date, updated = date};

            Script script_a = new Script { archived = false, updated = date,
             created = date, title = "script_a", description = "This is script_a"};

            Parameter param_1 = new Parameter { archived = false, updated = date,
             created = date, title = "param_a", description = "This is param_a", implemented = false };
            Parameter param_2 = new Parameter { archived = false, updated = date,
             created = date, title = "param_b", description = "This is param_b", implemented = false };
            Parameter param_3 = new Parameter { archived = false, updated = date,
             created = date, title = "param_c", description = "This is param_c", implemented = false };
            Parameter param_4 = new Parameter { archived = false, updated = date,
             created = date, title = "param_d", description = "This is param_d", implemented = false };
            Parameter param_5 = new Parameter { archived = false, updated = date,
             created = date, title = "param_e", description = "This is param_e", implemented = false };

            Option option_a = new Option { archived = false, updated = date,
             created = date, title = "option_a", description = "This is option_a", datatype = 1  };
            Option option_b = new Option { archived = false, updated = date,
             created = date, title = "option_b", description = "This is option_b", datatype = 1 };
            Option option_c = new Option { archived = false, updated = date,
             created = date, title = "option_c", description = "This is option_c", datatype = 1 };

            param_1.options.Add(option_a);
            param_2.options.Add(option_a);
            param_3.options.Add(option_b);
            param_4.options.Add(option_c);
            param_5.options.Add(option_a);

            option_a.parameter.Add(param_1);
            option_a.parameter.Add(param_2);
            option_a.parameter.Add(param_5);

            option_b.parameter.Add(param_3);
        	option_c.parameter.Add(param_4);

            param_3.parameter.Add(param_4);
            param_3.parameter.Add(param_5);

            script_a.parameter.Add(param_1);
            script_a.parameter.Add(param_2);
            script_a.parameter.Add(param_3);
            script_a.user = user_1;


            context.Add(user_1);
            context.Add(script_a);
            context.Add(option_b);
            context.Add(option_c);
            context.Add(param_1);
            context.Add(param_2);
            context.Add(param_3);
            context.Add(param_4);
            context.Add(param_5);
            context.Add(option_a);

            context.SaveChanges();
        }
    }

}