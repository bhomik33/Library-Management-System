using System;
using System.IO;
namespace LibraryManagement
{
    public class Newspaper : LibraryResource
    {
        private Format _format;
        private string _newspaperDate;
        private string _language;
        private int _id;

        public string NewspaperDate
        {
            get
            {
                return _newspaperDate;
            }
            set
            {
                _newspaperDate = value;
            }

        }

        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
            }
        }

        public int ID
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
        public Format Format
        {
            get
            {
                return _format;
            }
            set
            {
                _format = value;
            }
        }


        public Newspaper(string name, string newspaperDate, string language, int id, Format format) : base(name)
        {
            _newspaperDate = newspaperDate;
            _format = format;
            _language = language;
            _id = id;
        }
        public Newspaper() : this("Name", "Date", "language", 66, Format.Hardcover) { }

        public override string DisplayDetails()
        {
            return string.Format("*FOUND RESOURCE DETAILS*\n\nType => Newspaper \nName => {0}\nNewspaperDate => {1}\nLanguage => {2}\nId=> {3}\nStatus => {4}\nFormat => {5}", this.Name, this.NewspaperDate, this.Language, this.ID, this.Status, this.Format);

        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Newspaper");
            base.SaveTo(writer);
            writer.WriteLine(NewspaperDate);

            writer.WriteLine(Language);
            writer.WriteLine(ID);
            writer.WriteLine(Format.ToString());
        }


        public override void LoadFrom(StreamReader reader)
        {

            base.LoadFrom(reader);
            NewspaperDate = reader.ReadLine();
            Language = reader.ReadLine();
            ID = reader.ReadInteger();

            string format = reader.ReadLine();

            if (format == "Ebook")
            {
                Format = Format.Ebook;

            }
            if (format == "Audiobook")
            {
                Format = Format.Audiobook;

            }
            if (format == "Paperback")
            {
                Format = Format.Paperback;

            }
            if (format == "Hardcover")
            {
                Format = Format.Hardcover;

            }

        }


    }
}
