using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryManagement
{
    public class Member : Account
    {


        private int _memberId;
        private string _address;
        private string _phoneNumber;
        private int _itemsOnLoan;
        private LibraryManagementSystem _libraryManager = new LibraryManagementSystem();




        public int MemberId
        {
            get
            {
                return _memberId;
            }
            set
            {
                _memberId = value;
            }
        }


        public string Address
        {
            get
            {
                return _address;

            }
            set
            {
                _address = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;

            }
            set
            {
                _phoneNumber = value;
            }
        }

        public int ItemsOnLoan
        {
            get
            {
                return _itemsOnLoan;
            }
            set
            {
                _itemsOnLoan = value;
            }
        }

        public Member(string name, string username, string password, string address, string phoneNumber, int id, LibraryManagementSystem libraryManager) : base(name, username, password, libraryManager)
        {

            _address = address;
            _phoneNumber = phoneNumber;

            _memberId = id;
            _libraryManager = libraryManager;
            _itemsOnLoan = 0;



        }
        public string BorrowItem(string name, int memberId)
        {
            return LibraryManager.IssueItem(name, memberId);

        }
        public string ReturnItem(string name, int memberId)
        {

            return LibraryManager.ReturnItem(name, memberId);

        }
        public void UpdateDetails(string name, string username, string address, string phoneNumber)
        {
            this.Name = name;
            this.Username = username;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }
        public override string MyDetails()
        {
            return string.Format("\nName => {0}\nUsername => {1}\nMemberId => {2}\nAddress=> {3}\nPhoneNumber => {4}\nPassword ->{5} ", this.Name, this.Username, this.MemberId, this.Address, this.PhoneNumber, this.Password);

        }
        public string NumberofItemsOnLoan()
        {
            if (ItemsOnLoan == 0)
            {
                return "You have no items on loan";
            }
            return string.Format("The number of Item On Loan -> {0}", this.ItemsOnLoan);
        }
        public void Save(StreamWriter writer)
        {
            writer.WriteLine(Name);
            writer.WriteLine(Username);
            writer.WriteLine(Password);
            writer.WriteLine(Address);
            writer.WriteLine(PhoneNumber);
            writer.WriteLine(MemberId);
        }
        public void Load(StreamReader reader)
        {
            Name = reader.ReadLine();
            Username = reader.ReadLine();
            Password = reader.ReadLine();
            Address = reader.ReadLine();
            PhoneNumber = reader.ReadLine();
            MemberId = reader.ReadInteger();

        }


    }
}
