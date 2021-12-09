using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{


    public class NoteManager : IUserInterfaceManager
    {
       

        private readonly IUserInterfaceManager _parentUI;
        private AuthorRepository _authorRepository;
        private string _connectionString;
        private NoteRepository _noteRepository;

        public NoteManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _authorRepository = new AuthorRepository(connectionString);
            _connectionString = connectionString;
            _noteRepository = new NoteRepository(connectionString);
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Note Menu");
            Console.WriteLine(" 1) List Notes");
            Console.WriteLine(" 2) Add Notes");
            Console.WriteLine(" 3) Edit Notes");
            Console.WriteLine(" 4) Remove Notes");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List();
                    return this;
                case "2":
                    //Author author = Choose();
                    //if (author == null)
                    //{
                    //    return this;
                    //}
                    //else
                    //{
                    //    return new AuthorDetailManager(this, _connectionString, author.Id);
                    //}
                case "3":
                    Add();
                    return this;
                case "4":
                    Edit();
                    return this;
                case "5":
                    Remove();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void List()
        {
            List<Author> authors = _authorRepository.GetAll();
            foreach (Author author in authors)
            {
                Console.WriteLine(author);
            }
        }

        //private Author Choose(string prompt = null)
        //{
        //    if (prompt == null)
        //    {
        //        prompt = "Please choose an Author:";
        //    }

        //    Console.WriteLine(prompt);

        //    List<Author> authors = _authorRepository.GetAll();

        //    for (int i = 0; i < authors.Count; i++)
        //    {
        //        Author author = authors[i];
        //        Console.WriteLine($" {i + 1}) {author.FullName}");
        //    }
        //    Console.Write("> ");

        //    string input = Console.ReadLine();
        //    try
        //    {
        //        int choice = int.Parse(input);
        //        return authors[choice - 1];
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Invalid Selection");
        //        return null;
        //    }
        //}

        private void Add()
        {
            //Console.WriteLine("New Author");
            //Author author = new Author();

            //Console.Write("First Name: ");
            //author.FirstName = Console.ReadLine();

            //Console.Write("Last Name: ");
            //author.LastName = Console.ReadLine();

            //Console.Write("Bio: ");
            //author.Bio = Console.ReadLine();

            //_authorRepository.Insert(author);
        }

        private void Edit()
        {
            //Author authorToEdit = Choose("Which author would you like to edit?");
            //if (authorToEdit == null)
            //{
            //    return;
            //}

            //Console.WriteLine();
            //Console.Write("New first name (blank to leave unchanged: ");
            //string firstName = Console.ReadLine();
            //if (!string.IsNullOrWhiteSpace(firstName))
            //{
            //    authorToEdit.FirstName = firstName;
            //}
            //Console.Write("New last name (blank to leave unchanged: ");
            //string lastName = Console.ReadLine();
            //if (!string.IsNullOrWhiteSpace(lastName))
            //{
            //    authorToEdit.LastName = lastName;
            //}
            //Console.Write("New bio (blank to leave unchanged: ");
            //string bio = Console.ReadLine();
            //if (!string.IsNullOrWhiteSpace(bio))
            //{
            //    authorToEdit.Bio = bio;
            //}

            //_authorRepository.Update(authorToEdit);
        }

        private void Remove()
        {
            //Note noteToDelete = Choose("Which Note would you like to remove?");
            //if (noteToDelete != null)
            //{
            //    _noteRepository.Delete(noteToDelete.Id);
            //}
        }
    }
}
