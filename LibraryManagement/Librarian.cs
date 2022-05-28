using System;
namespace LibraryManagement
{
    public class Librarian : Account
    {



        public Librarian(string name, string username, string password, LibraryManagementSystem libraryManager) : base(name, username, password, libraryManager)
        {


        }


        // adding new members
        public void AddNewMember(Member m)
        {
            LibraryManager.AddMember(m);
        }
        // removing members
        public string RemoveExistingMember(int memberId)
        {
            return LibraryManager.RemoveMember(memberId);

        }
        // add new items
        public void AddNewItem(LibraryResource r)
        {
            LibraryManager.AddNewResource(r);
        }
        // remove items
        public string RemoveItem(string name)
        {
            return LibraryManager.RemoveResource(name);
        }


        public string AccessMemberDetails(int memberId)
        {
            return LibraryManager.ShowMemberDetails(memberId);
        }
        public void UpdateDetails(string name, string username)
        {
            this.Name = name;
            this.Username = username;
        }
        public override string MyDetails()
        {
            return string.Format("Name -> {0}\nUsername -> {1}\nPassword ->{2}", Name, Username, Password);
        }
    }
}
