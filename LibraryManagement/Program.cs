using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class Program
    {

        public static void Main()
        {
            // creating a library database
            LibraryDatabase library = new LibraryDatabase();

            //creating a shared library management system
            LibraryManagementSystem libraryManagementSystem = new LibraryManagementSystem();

            // admin account
            Librarian admin = new Librarian("testAdminUser", "testAdmin", "A1234", libraryManagementSystem);

            //add a library Resource
            LibraryResource book = new Book("Physics", "James", "2333", Format.Hardcover);

            //user account
            Member member1 = new Member("testMemberUser", "testMember", "M1234", "Unit3/762 Whitehorse Rd, Mont Albert 3127 VIC", "0426436916", 22, libraryManagementSystem);
            admin.AddNewMember(member1);
            admin.AddNewItem(book);


            LoginPage();

            Console.Write("Input Number -> ");
            int loginNumber = Convert.ToInt32(Console.ReadLine());

            // login number = 1 for admin login

            if (loginNumber == 1)
            {
                Console.WriteLine("\n");
                Console.WriteLine("****************** ADMIN LOGIN ***********************");



                int num2 = 0;
                while (num2 != 1)
                {
                    Console.WriteLine("\n");
                    Console.Write("Please enter the Username -> ");
                    string username = Console.ReadLine();
                    Console.WriteLine("\n");

                    Console.Write("Please enter the Password -> ");
                    string password = Console.ReadLine();
                    if (username != "testAdmin" || password != "A1234")
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Invalid username or Password!");
                        Console.WriteLine("Try again!");
                    }
                    else
                    {
                        Console.WriteLine("\n");
                        Console.Write("************ WELCOME TO SWIN LIBRARY ************");

                        num2 = 1;
                    }

                }
                if (num2 == 1)
                {
                    string input1 = "0";
                    while (input1 != "12")
                    {
                        AdminMenu();
                        Console.Write("Input Number -> ");
                        input1 = Console.ReadLine();

                        if (input1 == "1")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 1.SEARCH ITEM ************");


                            Console.Write("Please enter the name of item you want to search ->   ");
                            string itemName = Console.ReadLine();
                            Console.WriteLine("\n");
                            Console.WriteLine("**********************************************");
                            Console.WriteLine(member1.SearchItem(itemName));
                            Console.WriteLine("**********************************************");
                        }

                        if (input1 == "2")
                        {

                            Console.WriteLine("\n");
                            Console.WriteLine("************ 1.ADD MEMBER ************");

                            Console.Write("Please enter the Name -> ");
                            string newName = Console.ReadLine();
                            Console.Write("Please enter the Username -> ");
                            string newUsername = Console.ReadLine();
                            Console.Write("Please enter the Password -> ");
                            string newPassword = Console.ReadLine();
                            Console.Write("Please enter the Address -> ");
                            string newAddress = Console.ReadLine();
                            Console.Write("Please enter the PhoneNumber -> ");
                            string newPhoneNumber = Console.ReadLine();
                            Console.Write("Please enter the memberID -> ");
                            int memberId = Convert.ToInt32(Console.ReadLine());

                            Member member2 = new Member(newName, newUsername, newPassword, newAddress, newPhoneNumber, memberId, libraryManagementSystem);
                            admin.AddNewMember(member2);


                            Console.WriteLine("**********************************************");
                            Console.WriteLine("Member has been successfully added with memberID ->{0}", memberId);
                            Console.WriteLine("**********************************************");


                        }
                        // remove member
                        if (input1 == "3")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 1.REMOVE MEMBER ************");
                            Console.WriteLine("\n");
                            Console.Write("Please enter the memberID -> ");
                            int memberId = Convert.ToInt32(Console.ReadLine());

                            admin.RemoveExistingMember(memberId);

                            Console.WriteLine("**********************************************");
                            Console.WriteLine("Member has been successfully Removed!");
                            Console.WriteLine("**********************************************");
                        }

                        if (input1 == "4")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 4.ADD ITEM ************");
                            Console.WriteLine("\n");
                            Console.Write("Please enter the type of Resource -> ");
                            string type = Console.ReadLine();

                            if (type == "Book")
                            {
                                Console.Write("Please enter the name of Book -> ");
                                string name = Console.ReadLine();
                                Console.Write("Please enter the author of Book -> ");
                                string author = Console.ReadLine();
                                Console.Write("Please enter the isbn of Book -> ");
                                string isbn = Console.ReadLine();
                                Console.Write("Please enter the format of Book -> ");
                                string format = Console.ReadLine();
                                Format bookFormat = Format.Audiobook;

                                if (format == "Ebook")
                                {
                                    bookFormat = Format.Ebook;

                                }
                                if (format == "Audiobook")
                                {
                                    bookFormat = Format.Audiobook;

                                }
                                if (format == "Paperback")
                                {
                                    bookFormat = Format.Paperback;

                                }
                                if (format == "Hardcover")
                                {
                                    bookFormat = Format.Hardcover;

                                }
                                LibraryResource book1 = new Book(name, author, isbn, bookFormat);
                                admin.AddNewItem(book1);
                            }
                            if (type == "Laptop")
                            {
                                Console.Write("Please enter the companyName of Laptop -> ");
                                string name = Console.ReadLine();
                                Console.Write("Please enter the modelNumber -> ");
                                string modelNumber = Console.ReadLine();
                                Console.Write("Please enter the operatingSystem -> ");
                                string operatingSystem = Console.ReadLine();
                                Console.Write("Please enter the LaptopId -> ");
                                int laptopId = Convert.ToInt32(Console.ReadLine());

                                LibraryResource laptop = new Laptop(name, modelNumber, operatingSystem, laptopId);
                                admin.AddNewItem(laptop);
                            }
                            if (type == "Newspaper")
                            {
                                Console.Write("Please enter the Name of Newspaper -> ");
                                string name = Console.ReadLine();
                                Console.Write("Please enter the NewspaperDate -> ");
                                string newspaperDate = Console.ReadLine();
                                Console.Write("Please enter the language -> ");
                                string language = Console.ReadLine();
                                Console.Write("Please enter the newspaperId -> ");
                                int newspaperId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Please enter the format of Book -> ");
                                string format = Console.ReadLine();
                                Format NewspaperFormat = Format.Audiobook;

                                if (format == "Ebook")
                                {
                                    NewspaperFormat = Format.Ebook;

                                }
                                if (format == "Audiobook")
                                {
                                    NewspaperFormat = Format.Audiobook;

                                }
                                if (format == "Paperback")
                                {
                                    NewspaperFormat = Format.Paperback;

                                }
                                if (format == "Hardcover")
                                {
                                    NewspaperFormat = Format.Hardcover;

                                }
                                LibraryResource newspaper = new Newspaper(name, newspaperDate, language, newspaperId, NewspaperFormat);
                                admin.AddNewItem(newspaper);
                            }
                            Console.WriteLine("**********************************************");
                            Console.WriteLine("Item has been successfully added!");
                            Console.WriteLine("**********************************************");
                        }
                        if (input1 == "5")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 1.REMOVE ITEM ************");


                            Console.Write("Please enter the name of item you want to remove ->   ");
                            string itemName = Console.ReadLine();
                            Console.WriteLine("\n");
                            Console.WriteLine("**********************************************");
                            Console.WriteLine(admin.RemoveItem(itemName));
                            Console.WriteLine("**********************************************");

                        }

                        // file saving
                        if (input1 == "10")
                        {
                            libraryManagementSystem.SaveResource("/Users/bhomikkinger/Desktop/Resource.txt");
                            libraryManagementSystem.SaveMember("/Users/bhomikkinger/Desktop/Member.txt");
                            Console.WriteLine("Data has been saved successfully!");

                        }
                        //file loading
                        if (input1 == "11")
                        {

                            try
                            {
                                libraryManagementSystem.LoadResource("/Users/bhomikkinger/Desktop/Resource.txt");
                                libraryManagementSystem.LoadMembers("/Users/bhomikkinger/Desktop/Member.txt");
                                Console.WriteLine("Data has been loaded successfully!");

                            }
                            catch (Exception e)
                            {
                                Console.Error.WriteLine("Error loading file: {0}", e.Message);

                            }

                        }


                        if (input1 == "6")
                        {

                            Console.WriteLine("\n");
                            Console.WriteLine("************ 4.UPDATE DETAILS ************");
                            Console.WriteLine("\n");

                            Console.Write("Please enter the Name -> ");
                            string newName = Console.ReadLine();
                            Console.Write("Please enter the Username -> ");
                            string newUsername = Console.ReadLine();

                            admin.UpdateDetails(newName, newUsername);

                            Console.WriteLine("**********************************************");
                            Console.WriteLine("Congratulations! Your details has been updated!");
                            Console.WriteLine("**********************************************");
                        }



                        if (input1 == "7")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 7.ACCESS MEMBER DETAILS ************");
                            Console.WriteLine("\n");
                            Console.Write("Please enter the memberID -> ");
                            int memberId = Convert.ToInt32(Console.ReadLine());

                            admin.AccessMemberDetails(memberId);

                            Console.WriteLine("**********************************************");
                            Console.WriteLine(admin.AccessMemberDetails(memberId));
                            Console.WriteLine("**********************************************");
                        }




                        if (input1 == "8")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 7.RESET PASSWORD ************");
                            string newPassword;
                            Console.Write("Please enter the new Password -> ");
                            newPassword = Console.ReadLine();
                            admin.ResetPassword(newPassword);
                            Console.WriteLine("**********************************************");
                            Console.WriteLine("Password Reset Successful");
                            Console.WriteLine("**********************************************");
                        }


                        if (input1 == "9")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 5.SHOW MY DETAILS ************");
                            Console.WriteLine("\n");
                            Console.WriteLine("**********************************************");
                            Console.WriteLine(admin.MyDetails());
                            Console.WriteLine("**********************************************");

                        }
                    }


                }

            }

            // login Number 2 for member login
            if (loginNumber == 2)
            {
                //libraryManagementSystem.LoadResource("/Users/bhomikkinger/Desktop/Resource.txt");
                Console.WriteLine("\n");
                Console.WriteLine("****************** MEMBER LOGIN ***********************");



                int num = 0;
                while (num != 1)
                {
                    Console.WriteLine("\n");
                    Console.Write("Please enter the Username -> ");
                    string username = Console.ReadLine();
                    Console.WriteLine("\n");

                    Console.Write("Please enter the Password -> ");
                    string password = Console.ReadLine();

                    if (username != "testMember" || password != "M1234")
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Invalid username or Password!");
                        Console.WriteLine("Try again!");
                    }
                    else
                    {
                        Console.WriteLine("\n");
                        Console.Write("************ WELCOME TO SWIN LIBRARY ************");

                        num = 1;
                    }
                }
                if (num == 1)
                {
                    string input = "0";

                    while (input != "8")
                    {
                        MemberMenu();

                        Console.Write("Input Number -> ");
                        input = Console.ReadLine();
                        if (input == "1")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 1.SEARCH ITEM ************");


                            Console.Write("Please enter the name of item you want to search ->   ");
                            string itemName = Console.ReadLine();
                            Console.WriteLine("\n");
                            Console.WriteLine("**********************************************");
                            Console.WriteLine(member1.SearchItem(itemName));
                            Console.WriteLine("**********************************************");
                        }
                        if (input == "2")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 2.BORROW ITEM ************");
                            string itemName;
                            int memberId;
                            Console.Write("Please enter the itemName -> ");
                            itemName = Console.ReadLine();
                            Console.Write("Please enter the your memberID -> ");

                            memberId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("**********************************************");
                            Console.WriteLine(member1.BorrowItem(itemName, memberId));
                            Console.WriteLine("**********************************************");


                        }
                        if (input == "3")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 3.RETURN ITEM ************");
                            string itemName;

                            int memberId;

                            if (member1.ItemsOnLoan > 0)
                            {

                                Console.Write("Please enter the itemName -> ");
                                itemName = Console.ReadLine();

                                Console.Write("Please enter the your memberID -> ");

                                memberId = Convert.ToInt32(Console.ReadLine());


                                Console.WriteLine("**********************************************");
                                Console.WriteLine(member1.ReturnItem(itemName, memberId));
                                Console.WriteLine("**********************************************");


                            }
                            else
                            {
                                Console.WriteLine("You have no items on loan!");

                            }
                        }
                        if (input == "4")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 4.UPDATE DETAILS ************");
                            Console.WriteLine("\n");

                            Console.Write("Please enter the Name -> ");
                            string newName = Console.ReadLine();
                            Console.Write("Please enter the Username -> ");
                            string newUsername = Console.ReadLine();
                            Console.Write("Please enter the Address -> ");
                            string newAddress = Console.ReadLine();
                            Console.Write("Please enter the PhoneNumber -> ");
                            string newPhoneNumber = Console.ReadLine();
                            member1.UpdateDetails(newName, newUsername, newAddress, newPhoneNumber);

                            Console.WriteLine("**********************************************");
                            Console.WriteLine("Congratulations! Your details has been updated!");
                            Console.WriteLine("**********************************************");

                        }

                        if (input == "5")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 5.MY DETAILS ************");
                            Console.WriteLine("\n");
                            Console.WriteLine("**********************************************");
                            Console.WriteLine(member1.MyDetails());
                            Console.WriteLine("**********************************************");

                        }
                        if (input == "6")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 6.ITEMS ON LOAN ************");
                            Console.WriteLine("\n");
                            Console.WriteLine("**********************************************");
                            Console.WriteLine(member1.NumberofItemsOnLoan());
                            Console.WriteLine("**********************************************");

                        }
                        if (input == "7")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("************ 7.RESET PASSWORD ************");
                            string newPassword;
                            Console.Write("Please enter the new Password -> ");
                            newPassword = Console.ReadLine();
                            member1.ResetPassword(newPassword);
                            Console.WriteLine("**********************************************");
                            Console.WriteLine("Password Reset Successful");
                            Console.WriteLine("**********************************************");
                        }
                    }
                }
            }
        }
        public static void LoginPage()
        {
            Console.WriteLine("************ Welcome to SWIN LIBRARY LOGIN PAGE ************");
            Console.WriteLine("\n");
            Console.WriteLine("1.Press 1 for ADMIN LOGIN");
            Console.WriteLine("2.Press 2 for MEMBER LOGIN");
            Console.WriteLine("\n");

        }
        public static void MemberMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("************ MENU ************");


            Console.WriteLine("\n");
            Console.WriteLine("************ 1.SEARCH ITEM ************");
            Console.WriteLine("************ 2.BORROW ITEM ************");
            Console.WriteLine("************ 3.RETURN ITEM ************");
            Console.WriteLine("************ 4.UPDATE DETAILS ************");
            Console.WriteLine("************ 5.MY DETAILS ************");
            Console.WriteLine("************ 6.ITEMS ON LOAN ************");
            Console.WriteLine("************ 7.RESET PASSWORD ************");
            Console.WriteLine("************ 8.LOGOUT ************");
            Console.WriteLine("\n");
        }
        public static void AdminMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("************ MENU ************");
            Console.WriteLine("\n");
            Console.WriteLine("************ 1.SEARCH ITEM ************");
            Console.WriteLine("************ 2.ADD MEMBER ************");
            Console.WriteLine("************ 3.REMOVE MEMBER ************");
            Console.WriteLine("************ 4.ADD ITEM ************");
            Console.WriteLine("************ 5.REMOVE ITEM ************");
            Console.WriteLine("************ 6.UPDATE DETAILS ************");
            Console.WriteLine("************ 7.ACCESS MEMBER DETAILS ************");
            Console.WriteLine("************ 8.RESET PASSWORD ************");
            Console.WriteLine("************ 9.SHOW MY DETAILS ************");
            Console.WriteLine("************ 10.SAVE ***********************");
            Console.WriteLine("************ 11.LOAD ************");
            Console.WriteLine("************ 12.LOGOUT ************");
            Console.WriteLine("\n");

        }
    }
}






