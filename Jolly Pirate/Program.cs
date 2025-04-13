using Jolly_Pirate.controller;
using Jolly_Pirate.model;
using Jolly_Pirate.view;

namespace Jolly_Pirate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            MembersRegistry m = new MembersRegistry(db);
            View v = new View();
            Controller c = new Controller(db);

            try
            {
                c.Run(v, m);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unfortunately something unexpected happened!");
                Console.WriteLine("Please restart the application!");
                Console.WriteLine(ex.Message);
            }
            

            Console.ReadKey();
        }
    }
}
