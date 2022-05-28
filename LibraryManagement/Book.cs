using System;
using System.IO;
namespace LibraryManagement
{
    public class Book : LibraryResource
    {

        private string _author;
        private string _isbn;
        private Format _format;



        public Book(string name, string author, string isbn, Format format) : base(name)
        {
            _author = author;
            _isbn = isbn;
            _format = format;


        }
        public Book() : this("name", "author", "444", Format.Audiobook) { }

        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        public string ISBN
        {
            get
            {
                return _isbn;
            }
            set
            {
                _isbn = value;
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
        public override string DisplayDetails()
        {
            return string.Format("*FOUND RESOURCE DETAILS*\n\nType => Book \nName => {0}\nAuthor => {1}\nISBN => {2}\nStatus => {3}\nFormat => {4}", this.Name, this.Author, this.ISBN, this.Status, this.Format);
        }


        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Book");
            base.SaveTo(writer);
            writer.WriteLine(Author);
            writer.WriteLine(ISBN);
            writer.WriteLine(Format.ToString());

        }
        public override void LoadFrom(StreamReader reader)
        {

            base.LoadFrom(reader);
            Author = reader.ReadLine();
            ISBN = reader.ReadLine();
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
