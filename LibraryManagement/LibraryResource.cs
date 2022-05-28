using System;
using System.Collections.Generic;
using System.IO;
namespace LibraryManagement
{
    public abstract class LibraryResource
    {

        private Status _status;
        private string _name;

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
        public Status Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }

        }

        public LibraryResource(string name)
        {

            _status = Status.Available;


            _name = name;

        }
        public abstract string DisplayDetails();
        public void UpdateStatus(Status s)
        {
            this.Status = s;
        }
        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(Name);
            writer.WriteLine(Status);


        }
        public virtual void LoadFrom(StreamReader reader)
        {
            Name = reader.ReadLine();
            string status = reader.ReadLine();
            if (status == "Available")
            {
                Status = Status.Available;
            }
            if (status == "Loaned")
            {
                Status = Status.Loaned;
            }
            if (status == "Reserved")
            {
                Status = Status.Reserved;
            }
            if (status == "Lost")
            {
                Status = Status.Lost;
            }

        }
    }
}
