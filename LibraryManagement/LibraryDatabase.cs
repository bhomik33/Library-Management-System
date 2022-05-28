using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class LibraryDatabase
    {

        private List<LibraryResource> _resources;
        private List<Member> _members;


        public List<LibraryResource> Resources
        {
            get
            {
                return _resources;
            }
        }

        public List<Member> Members
        {
            get
            {
                return _members;
            }
        }

        public LibraryDatabase()
        {

            _resources = new List<LibraryResource>();
            _members = new List<Member>();

        }
        public bool LocateResource(string name)
        {
            foreach (LibraryResource r in Resources)
            {
                if (r.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public bool LocateMember(int memberId)
        {
            foreach (Member m in Members)
            {
                if (m.MemberId == memberId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
