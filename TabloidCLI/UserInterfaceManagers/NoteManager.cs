using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{


    public class NoteManager : IUserInterfaceManager
    {


        private readonly IUserInterfaceManager _parentUI;
        private PostRepository _postRepository;
        private string _connectionString;
        private NoteRepository _noteRepository;

        public NoteManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _postRepository = new PostRepository(connectionString);
            _connectionString = connectionString;
            _noteRepository = new NoteRepository(connectionString);
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Note Menu");
            Console.WriteLine(" 1) List Notes");
            Console.WriteLine(" 2) Add Notes");
            Console.WriteLine(" 3) Remove Notes");
            Console.WriteLine(" 0) Go Back");
            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List();
                    return this;
                case "2":
                    Add();
                    return this;
                case "3":
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
            //List<Author> authors = _authorRepository.GetAll();
            //foreach (Author author in authors)
            //{
            //    Console.WriteLine(author);
            //}
        }

        private Post ChoosePost(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose an Post:";
            }

            Console.WriteLine(prompt);

            List<Post> posts = _postRepository.GetAll();

            for (int i = 0; i < posts.Count; i++)
            {
                Post post = posts[i];
                Console.WriteLine($" {i + 1}) {post.Title}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return posts[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }

        private void Add()
        {
            Console.WriteLine("New Note");
            Note note = new Note();

            Console.Write("Title: ");
            note.Title = Console.ReadLine();

            Console.Write("Text: ");
            note.Text = Console.ReadLine();

            note.Post = ChoosePost("Post:");

            note.CreationDate = DateTime.Now;

            _noteRepository.Insert(note);
            
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
