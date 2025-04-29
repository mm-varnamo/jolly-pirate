using Jolly_Pirate.model;
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
            Quit,
            RegisterMember,
            EditMember,
            DeleteMember,
            RegisterBoat,
            EditBoat,
            DeleteBoat,
            ViewSimpleMembersList,
            ViewDetailedMembersList,
            ViewSpecificMember,
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
            Console.WriteLine("1. Register a new member");
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

        public ActionTaken GetUsersInput()
        {
            char usersChoice = Console.ReadKey().KeyChar;

            switch (usersChoice)
            {
                case '1': return ActionTaken.RegisterMember;
                case '2': return ActionTaken.EditMember;
                case '3': return ActionTaken.DeleteMember;
                case '4': return ActionTaken.RegisterBoat;
                case '5': return ActionTaken.EditBoat;
                case '6': return ActionTaken.DeleteBoat;
                case '7': return ActionTaken.ViewSimpleMembersList;
                case '8': return ActionTaken.ViewDetailedMembersList;
                case '9': return ActionTaken.ViewSpecificMember;
                case '0': return ActionTaken.Quit;
                default: return ActionTaken.None;
            }
        }

        public Member RegisterMember()
        {
            string name;
            string socialSecurityNumber;

            do
            {
                RenderLogo();
                Console.WriteLine("Register a new member");
                Console.WriteLine();
                Console.WriteLine("Type the members name:");
                name = Console.ReadLine() ?? "";
            } while (name.Length == 0);

            do
            {
                Console.WriteLine();
                Console.WriteLine("Type the members social security number, follow the format yymmddxxxx: ");
                socialSecurityNumber = Console.ReadLine() ?? "";
            } while (socialSecurityNumber.Length != 10 || !socialSecurityNumber.All(char.IsDigit));

            Console.ForegroundColor = ConsoleColor.Green;
            Member member = new Member(name, socialSecurityNumber);
            Console.WriteLine();
            Console.WriteLine("The member was successfully registered.");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
            return member;
        }

        public void EditMember(Member member)
        {
            string socialSecurityNumber;
            string name;

            RenderLogo();

            do
            {
                Console.WriteLine();
                Console.WriteLine($"Edit member {member.Name}'s name ");
                Console.WriteLine("Type the new name: ");
                name = Console.ReadLine() ?? "";
            } while (name.Length == 0);

            Console.Clear();
            RenderLogo();

            do
            {
                Console.WriteLine();
                Console.WriteLine($"Edit member {member.Name}'s social security number ");
                Console.WriteLine("Type the new social security number, follow the format yymmddxxxx:");
                socialSecurityNumber = Console.ReadLine() ?? "";
            } while (socialSecurityNumber.Length != 10);

            member.SetName(name);
            member.SetSocialSecurityNumber(socialSecurityNumber);

            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();
        }

        public void DeleteMember(Member member)
        {
            Console.Clear();
            RenderLogo();

            Console.WriteLine($"{member.Name} was deleted successfully!");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public Boat RegisterBoat()
        {
 
            RenderLogo();
            Console.WriteLine("Register boat to member");
            Console.WriteLine();

            Boat boat = InputBoatData();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The bost was registered to the selected user.");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();

            return boat;
        }

        public Boat EditBoat()
        {
            RenderLogo();
            Console.WriteLine("Edit a members boat");

            Boat boat = InputBoatData();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The members boat was successfuly updated.");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadLine();

            return boat;
        }

        public int DeleteBoat(Member member)
        {
            RenderLogo();
            Console.WriteLine($"Delete {member.Name}'s boat");

            int index = 0;

            foreach (var boat in member.GetBoatList())
            {
                Console.WriteLine($"Index: {index}, Type: {boat.Type}, Length: {boat.Length}");
                index++;
            }

            int indexOfBoat;

            do
            {
                Console.WriteLine("Choose the index of the boat you want to remove and press return.");
                indexOfBoat = Int32.Parse(Console.ReadLine());
            } while (indexOfBoat < 0 && indexOfBoat > member.GetBoatList().Count - 1);

            Console.WriteLine("The boat was successfully removed");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();

            return indexOfBoat;
        }

        private Boat InputBoatData()
        {
            int length;
            int typeChoice;

            do
            {
                Console.WriteLine("Enter boat length:");
            } while (!int.TryParse(Console.ReadLine(), out length));

            do
            {
                Console.WriteLine("Enter boat type:");
                Console.WriteLine("1.Canoe 2.Battle Ship 3.Yacht 4.Sub-Marine");
                typeChoice = Int32.Parse(Console.ReadLine());

            } while (typeChoice < 1 || typeChoice > 4);

            BoatType type = (BoatType)typeChoice;

            Boat boat = new Boat(length, type);

            return boat;
        }

        public Guid SelectUserByID(List<Member> membersList)
        {
            Guid membersID;
            bool isValidID = false;

            RenderLogo();
            Console.WriteLine("Select the member's ID");
            Console.WriteLine();

            foreach (var member in membersList)
            {
                Console.WriteLine($"Name: {member.Name} Social Number: {member.SocialSecurityNumber} Id: {member.UniqueID}");
            }

            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter the members ID:");
                string input = Console.ReadLine();

                if (Guid.TryParse(input, out membersID))
                {
                    isValidID = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid ID. Please try again.");
                    Console.ResetColor();
                }
            } while (!isValidID);

            Console.WriteLine(membersID);
            return membersID;
        }

        public void ViewSimpleMembersList(List<Member> membersList)
        {
            RenderLogo();
            Console.WriteLine();

            foreach (var member in membersList)
            {
                Console.WriteLine($"Name: {member.Name} Social Number: {member.SocialSecurityNumber} Id: {member.UniqueID} Amount of boats: {member.GetBoatCount()}");
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Press the return key to return to the main menu.");
            Console.ReadLine();
        }

        public void ViewDetailedMembersList(List<Member> membersList)
        {
            RenderLogo();
            Console.WriteLine("You are viewing a detailed list of the registered members");
            Console.WriteLine();

            foreach(var member in membersList)
            {
                Console.WriteLine($"Name: {member.Name} Personal Number: {member.SocialSecurityNumber} ID: {member.UniqueID}");
                Console.WriteLine();
                Console.WriteLine($"{member.Name}'s registered boats:");

                DisplayMemberBoats(member.GetBoatList());

                Console.WriteLine();
            }

            Console.WriteLine("Enter any key to return to the main menu.");
            Console.ReadKey();
        }

        public void ViewSpecificMember(Member member)
        {
            RenderLogo();
            Console.WriteLine($"Name: {member.Name} Personal Number: {member.SocialSecurityNumber} ID: {member.UniqueID}");

            DisplayMemberBoats(member.GetBoatList());

            Console.WriteLine();
            Console.WriteLine("Enter any key to return to the main menu.");
            Console.ReadKey();
        }

        public void DisplayMemberBoats(IReadOnlyList<Boat> boats)
        {
            foreach (var boat in boats)
            {
                Console.WriteLine($"Boat type: {boat.Type}, Boat length: {boat.Length}");
            }
        }

        public int GetIndexOfBoat(IEnumerable<Boat> boats)
        {
            RenderLogo();
            int indexOfBoat = 0;

            foreach (var boat in boats)
            {
                Console.WriteLine($"Index: {indexOfBoat} Type: {boat.Type} Length: {boat.Length}");
                indexOfBoat++;
            }

            bool isValidIndex = false;
            int chosenIndex;

            do
            {
                Console.WriteLine("Enter the index of the boat you would like to edit and then press enter.");
                chosenIndex = Int32.Parse(Console.ReadLine());
                
                if (chosenIndex >= 0 || chosenIndex < (boats.Count() - 1))
                {
                    isValidIndex = true;
                }

            } while (!isValidIndex);

            return chosenIndex;
        }

        public void ShowInputError(string errorMessage)
        {
            Console.Clear();
            RenderLogo();

            Console.WriteLine(errorMessage);
            Console.WriteLine("Press the return key to return to the main menu.");
            Console.ReadLine();
        }
    }
}
