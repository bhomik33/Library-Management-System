using System;

namespace LibraryManagement
{
    public abstract class Account
    {
        private string _name;
        private string _username;
        private string _password;
        private LibraryManagementSystem _libraryManager;


        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }

        }


        public LibraryManagementSystem LibraryManager
        {
            get
            {
                return _libraryManager;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }


        public Account(string name, string username, string password, LibraryManagementSystem libraryManager)
        {
            _name = name;
            _username = username;
            _password = password;
            _libraryManager = libraryManager;
        }
        public void ResetPassword(string password)
        {
            this._password = password;
        }
        public abstract string MyDetails();


        public string SearchItem(string name)
        {
            if (LibraryManager.SearchResource(name))
            {
                return LibraryManager.ShowItemDetails(name);
            }
            return "Resource not found!";
        }

    }
}
