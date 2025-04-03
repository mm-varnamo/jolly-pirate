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

        public void renderLogo()
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
    }
}
