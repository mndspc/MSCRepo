using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
namespace DAL
{
    internal class Program
    {
        static void Main()
        {
          
            Director director=new Director {DirectorId=1,Name="Priy Darshan" };
            using(MSCDbEntities dbContext=new MSCDbEntities())
            {
                dbContext.Directors.Add(director);
                dbContext.SaveChanges();
                Console.WriteLine("Database Created");
            }
        }
    }
}
