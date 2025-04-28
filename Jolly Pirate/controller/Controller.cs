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
                        List<Member> members = membersRegistry.GetMembersList();
                        var membersID = view.SelectUserByID(members);
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

                if (usersInput == View.ActionTaken.EditBoat)
                {
                    try
                    {
                        Guid usersID = view.SelectUserByID(membersRegistry.GetMembersList());
                        int indexOfBoat = view.GetIndexOfBoat(membersRegistry.GetMemberByID(usersID).GetBoatList());

                        Member member = membersRegistry.GetMemberByID(usersID);

                        member.UpdateBoatValues(view.EditBoat(), indexOfBoat);

                        db.SaveMembersRegistryToDB(membersRegistry.GetMembersList());
                    } catch (ArgumentOutOfRangeException ex)
                    {
                        view.ShowInputError(ex.Message);
                    }
                }

                if (usersInput == View.ActionTaken.DeleteBoat)
                {
                    try
                    {
                        List<Member> membersList = membersRegistry.GetMembersList();
                        Guid membersID = view.SelectUserByID(membersList);
                        Member member = membersRegistry.GetMemberByID(membersID);

                        if (member.Boats.Count == 0)
                        {

                        }

                        int indexOfBoat = view.DeleteBoat(member);
                        member.RemoveBoat(indexOfBoat);

                        db.SaveMembersRegistryToDB(membersRegistry.GetMembersList());
                    } 
                    catch (Exception ex) 
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
