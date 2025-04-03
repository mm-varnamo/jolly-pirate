using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jolly_Pirate.view
{
    public class View
    {
        public enum ActionTaken
        {
            RegisterMember,
            EditMember,
            DeleteMember,
            RegisterBoat,
            EditBoat,
            DeleteBoat,
            ViewSimpleList,
            ViewDetailedList,
            ViewSpecificMemeber,
            Quit,
            None
        }

        public void RenderLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("X======================X");
            Console.WriteLine("X                      X");
            Console.WriteLine("X   The Jolly Pirate   X");
            Console.WriteLine("X                      X");
            Console.WriteLine("X======================X");
            Console.ResetColor();
        }

        public void RenderMainMenu()
        {
            RenderLogo();
            Console.WriteLine("1. Register a new memeber");
            Console.WriteLine("2. Edit a member");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3. Delete a member");
            Console.ResetColor();
            Console.WriteLine("4. Register a boat to a member");
            Console.WriteLine("5. Edit a members boat");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6. Delete a members boat");
            Console.ResetColor();
            Console.WriteLine("7. View a simple list of members");
            Console.WriteLine("8. View a detailed list of members");
            Console.WriteLine("9. View a specific members information");
            Console.WriteLine("0. Quit the program");

        }
    }
}
