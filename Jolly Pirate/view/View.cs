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
    }
}
