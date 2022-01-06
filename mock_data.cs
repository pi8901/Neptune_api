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
            Script script_b = new Script { archived = false, updated = date,
             created = date, title = "script_b", description = "This is script_b"};

            Parameter param_1 = new Parameter { archived = false, updated = date,
             created = date, title = "param_a", description = "This is param_a" };
            Parameter param_2 = new Parameter { archived = false, updated = date,
             created = date, title = "param_b", description = "This is param_b" };
            Parameter param_3 = new Parameter { archived = false, updated = date,
             created = date, title = "param_c", description = "This is param_c" };
            Parameter param_4 = new Parameter { archived = false, updated = date,
             created = date, title = "param_d", description = "This is param_d" };
            Parameter param_5 = new Parameter { archived = false, updated = date,
             created = date, title = "param_e", description = "This is param_e" };

            Option option_a = new Option { archived = false, updated = date,
             created = date, title = "option_a", description = "This is option_a", datatype = 0  };
            Option option_b = new Option { archived = false, updated = date,
             created = date, title = "option_b", description = "This is option_b", datatype = 1 };
            Option option_c = new Option { archived = false, updated = date,
             created = date, title = "option_c", description = "This is option_c", datatype = 2 };

            param_1.options.Add(option_a);
            param_2.options.Add(option_a);
            param_3.options.Add(option_b);
            param_4.options.Add(option_c);
            param_5.options.Add(option_a);


            param_3.parameter_child.Add(param_4);
            param_3.parameter_child.Add(param_5);

            ScriptParameter sp1 = new ScriptParameter{script = script_a, parameter = param_1, implemented = false};
            ScriptParameter sp2 = new ScriptParameter{script = script_a, parameter = param_2, implemented = false};
            ScriptParameter sp3 = new ScriptParameter{script = script_a, parameter = param_3, implemented = true};

            script_a.user = user_1;

            ScriptParameter sp4 = new ScriptParameter{script = script_b, parameter = param_2, implemented = false};
            ScriptParameter sp5 = new ScriptParameter{script = script_b, parameter = param_1, implemented = true};
            ScriptParameter sp6 = new ScriptParameter{script = script_b, parameter = param_5, implemented = true};

            script_b.user = user_1;

            context.Add(user_1);
            context.Add(script_a);
            context.Add(script_b);
            context.Add(option_b);
            context.Add(option_c);
            context.Add(param_1);
            context.Add(param_2);
            context.Add(param_3);
            context.Add(param_4);
            context.Add(param_5);
            context.Add(option_a);

            context.Add(sp1);
            context.Add(sp2);
            context.Add(sp3);
            context.Add(sp4);
            context.Add(sp5);
            context.Add(sp6);

            context.SaveChanges();
        }
    }

}