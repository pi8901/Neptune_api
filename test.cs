using System;
using System.Text;
using Neptune.Models;
using Neptune.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Neptune
{
    public class test
    {
        public test()
        {
            

            DatabaseDbContext context = new DatabaseDbContext();

            string jsonString = JsonSerializer.Serialize(context.scripts.ToListAsync());
            Console.WriteLine(jsonString);
            Script s;

            foreach (var script in context.scripts.Include(b => b.parameter).Include(c => c.user))
            {
                Console.WriteLine(script.title);
                s = script;
                Console.WriteLine(s.user.display_name);
                foreach (var parameter in script.parameter)
                {
                    Console.WriteLine(parameter.title);
                }
            }
            var scripts = context.scripts.Include(b=> b.parameter);
            //Script c =  scripts.FirstAsync();
            
        }
    }

}