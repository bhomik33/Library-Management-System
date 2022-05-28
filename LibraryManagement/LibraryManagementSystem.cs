using System;
using System.IO;
namespace LibraryManagement
{
    public class LibraryManagementSystem
    {
        private LibraryDatabase _libraryDatabase;

        public LibraryDatabase LibraryDatabase
        {
            get
            {
                return _libraryDatabase;
            }
        }
        public int ResourceCount
        {
            get
            {
                return LibraryDatabase.Resources.Count;
            }
        }
        public int MemberCount
        {
            get
            {
                return LibraryDatabase.Members.Count;
            }
        }

        public LibraryManagementSystem()
        {
            _libraryDatabase = new LibraryDatabase();
        }
        public void AddNewResource(LibraryResource resource)
        {
            LibraryDatabase.Resources.Add(resource);
        }
        public string RemoveResource(string name)
        {
            foreach (LibraryResource r in LibraryDatabase.Resources)
            {
                if (r.Name == name && r.Status == Status.Available)
                {
                    LibraryDatabase.Resources.Remove(r);
                    return "Item has been successfully removed";
                }
            }
            return "Item not found!";
        }
        public void AddMember(Member m)
        {
            LibraryDatabase.Members.Add(m)
;
        }
        public string RemoveMember(int memberId)
        {
            foreach (Member m in LibraryDatabase.Members)
            {
                if (m.MemberId == memberId)
                {
                    LibraryDatabase.Members.Remove(m);
                    return "Member has been successfully removed!";
                }
            }
            return "Invalid memberID!";
        }
        public bool SearchResource(string name)
        {
            if (LibraryDatabase.LocateResource(name))
            {
                return true;
            }
            return false;

        }
        public string ShowItemDetails(string name)
        {
            foreach (LibraryResource r in LibraryDatabase.Resources)
            {
                if (r.Name == name)
                {
                    return r.DisplayDetails();
                }
            }
            return null;

        }

        public string ShowMemberDetails(int memberId)
        {
            foreach (Member m in LibraryDatabase.Members)
            {
                if (m.MemberId == memberId)
                {
                    return m.MyDetails();
                }
            }
            return "Invalid Id. Member not found!";
        }
        public string IssueItem(string name, int memberId)
        {
            if (LibraryDatabase.LocateMember(memberId) != true)
            {
                return "Sorry! You are not a registered Member";
            }
            foreach (LibraryResource r in LibraryDatabase.Resources)
            {
                if (SearchResource(name) != true)
                {
                    return "Resource not found!";

                }
                if (SearchResource(name) == true && r.Status == Status.Loaned)
                {
                    return "Sorry! Resource is available at the moment!";
                }
                else
                {
                    if (r.Name == name)
                    {
                        r.UpdateStatus(Status.Loaned);

                        foreach (Member m in LibraryDatabase.Members)
                        {
                            if (m.MemberId == memberId)
                            {

                                m.ItemsOnLoan++;

                            }
                        }

                    }
                }


            }
            return "Book has been successfully issued!";
        }
        public void SaveResource(String filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(ResourceCount);
            foreach (LibraryResource r in LibraryDatabase.Resources)
            {
                r.SaveTo(writer);
            }
            writer.Close();
        }

        public void LoadResource(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try
            {
                int count = reader.ReadInteger();

                for (int i = 0; i < count; i++)
                {

                    string type = reader.ReadLine();
                    LibraryResource r;

                    switch (type)
                    {
                        case "Book":
                            r = new Book();
                            break;
                        case "Laptop":
                            r = new Laptop();
                            break;
                        case "Newspaper":
                            r = new Newspaper();
                            break;
                        default:
                            throw new InvalidDataException("Unknown resource type: " + type);

                    }
                    r.LoadFrom(reader);
                    AddNewResource(r);

                }

            }
            finally
            {
                reader.Close();
            }



        }
        public void SaveMember(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(MemberCount);
            foreach (Member m in LibraryDatabase.Members)
            {
                m.Save(writer);
            }
            writer.Close();

        }

        public void LoadMembers(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try
            {
                int count = reader.ReadInteger();

                for (int i = 0; i < count; i++)
                {
                    Member m;
                    m = new Member("name", "username", "password", "Address", "23444422", 1, this);
                    m.Load(reader);
                    AddMember(m);
                }
            }
            finally
            {
                reader.Close();
            }


        }
        public string ReturnItem(string name, int memberId)
        {
            foreach (Member m in LibraryDatabase.Members)
            {
                if (m.MemberId == memberId)
                {

                    m.ItemsOnLoan--;
                }
            }
            foreach (LibraryResource r in LibraryDatabase.Resources)
            {
                if (r.Name == name)
                {
                    r.UpdateStatus(Status.Available);
                   
                }
            }
            return "The item has been successfully returned!";

        }




    }


}
