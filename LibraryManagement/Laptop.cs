using System;
using System.IO;
namespace LibraryManagement
{
    public class Laptop : LibraryResource
    {

        private string _modelNumber;
        private string _operatingSystem;
        private int _id;

        public string ModelNumber
        {
            get
            {
                return _modelNumber;
            }
            set
            {
                _modelNumber = value;
            }

        }
        public string OperatingSystem
        {
            get
            {
                return _operatingSystem;
            }
            set
            {
                _operatingSystem = value;
            }

        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }

        }

        public Laptop(string name, string modelNumber, string operatingSystem, int id) : base(name)
        {
            _modelNumber = modelNumber;
            _operatingSystem = operatingSystem;
            _id = id;
        }
        public Laptop() : this("name", "modelNumber", "operatingSystem", 33) { }
        public override string DisplayDetails()
        {
            return string.Format("*FOUND RESOURCE DETAILS*\n\nType => Laptop \nCompanyName => {0}\nModelNumber => {1}\nOperatingSystem => {2}\nLaptopID => {3}\nStatus => {4}", this.Name, this.ModelNumber, this.OperatingSystem, this.Id, this.Status);

        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Laptop");
            base.SaveTo(writer);
            writer.WriteLine(ModelNumber);
            writer.WriteLine(OperatingSystem);
            writer.WriteLine(Id);
        }
        public override void LoadFrom(StreamReader reader)
        {

            base.LoadFrom(reader);
            ModelNumber = reader.ReadLine();
            OperatingSystem = reader.ReadLine();
            Id = reader.ReadInteger();
        }
    }
}
