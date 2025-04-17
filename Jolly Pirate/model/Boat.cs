using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jolly_Pirate.model
{
    public enum BoatType
    {
        Canoe = 1,
        BattleShip = 2,
        Yacht = 3,
        SubMarine = 4
    }
    public class Boat
    {
        private int _length;
        private BoatType _type;
        public Boat(int length, BoatType type)
        {
            Length = length;
            Type = type;
        }

        public int Length
        {
            get => _length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Boat length must be greater than zero.");
                }
                else
                {
                    _length = value;
                }

            }
        }

        public BoatType Type
        {

            get => _type;
            set
            {
                if (!Enum.IsDefined(typeof(BoatType), value))
                {
                    throw new ArgumentOutOfRangeException("Invalid boat type provided.");
                }
                else
                {
                    _type = value;
                }
            }
        }
    }
}
