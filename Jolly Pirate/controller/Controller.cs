using Jolly_Pirate.model;
using Jolly_Pirate.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jolly_Pirate.controller
{
    public class Controller
    {
        Database db;
        public Controller(Database db)
        {
            this.db = db;
        }

        public void Run(View view, MembersRegistry membersRegistry)
        {
            view.RenderMainMenu();
            var usersInput = view.GetUsersInput();

            while (usersInput != View.ActionTaken.Quit)
            {
                if (usersInput == View.ActionTaken.RegisterMember)
                {
                    Member member = view.RegisterMember();
                    membersRegistry.AddMember(member);
                    db.SaveMembersRegistryToDB(membersRegistry.GetMembersList());
                }

                if (usersInput == View.ActionTaken.EditMember)
                {
                    try
                    {
                        var membersID = view.SelectUserByID(membersRegistry.GetMembersList());
                        var memberToEdit = membersRegistry.GetMemberByID(membersID);
                        view.EditMember(memberToEdit);

                        db.SaveMembersRegistryToDB(membersRegistry.GetMembersList());
                    }
                    catch (ArgumentOutOfRangeException ex) {

                        view.ShowInputError(ex.Message);
                        view.RenderMainMenu();
                    }
                }

                if (usersInput == View.ActionTaken.DeleteMember)
                {
                    try
                    {
                        var membersList = membersRegistry.GetMembersList();
                        var membersID = view.SelectUserByID(membersList);
                        var memberToDelete = membersList.Find(m => m.UniqueID ==  membersID);

                        if (memberToDelete == null)
                        {
                            view.ShowInputError("No member found with the given ID.");
                            view.RenderMainMenu();
                            return;
                        }

                        view.DeleteMember(memberToDelete);

                        membersRegistry.DeleteMember(membersID);
                        db.SaveMembersRegistryToDB(membersRegistry.GetMembersList());
                    } catch (ArgumentOutOfRangeException ex)
                    {
                        view.ShowInputError(ex.Message);
                        view.RenderMainMenu();
                    }
                }

                if (usersInput == View.ActionTaken.RegisterBoat)
                {
                    try
                    {
                        Guid usersID = view.SelectUserByID(membersRegistry.GetMembersList());
                        membersRegistry.GetMemberByID(usersID).AddBoat(view.RegisterBoat());
                        db.SaveMembersRegistryToDB(membersRegistry.GetMembersList());
                    } catch (ArgumentOutOfRangeException ex)
                    {
                        view.ShowInputError(ex.Message);
                    }
                }

                if (usersInput == View.ActionTaken.ViewSimpleMembersList)
                {
                    var members = membersRegistry.GetMembersList();
                    view.ViewSimpleMembersList(members);
                }
 
                view.RenderMainMenu();
                usersInput = view.GetUsersInput();
            }
        }
    }
}
