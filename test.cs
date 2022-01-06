using System;
using Neptune.Models;
using Neptune.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Neptune
{
    public class test
    {
        public test()
        {

            DatabaseDbContext context = new DatabaseDbContext();
            Script s;

            var x = context.scripts.Where(m => m.Id == 2).FirstOrDefault();
            var z = context.scriptParameter.Where(m => m.script.Id == 2 && m.implemented == true).Include(m => m.parameter).ToList();
            var t = context.scriptParameter.Where(m => m.script.Id == 2 && m.implemented == true).Select(m => m.parameter).ToList();
            //var x = context.scripts.Where(m => m.Id == 1)

            foreach (var y in t)
            {
                Console.WriteLine(y.title);
            }  
        }
    }

}