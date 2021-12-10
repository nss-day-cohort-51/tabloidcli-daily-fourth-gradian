//using System;
//using System.Collections.Generic;
//using TabloidCLI.Models;

//namespace TabloidCLI.UserInterfaceManagers
//{
//    public class NoteManager : IUserInterfaceManager
//    {
//        private readonly IUserInterfaceManager _parentUI;
//        //private NoteRepository _noteRepository;
//        private string _connectionString;

//        public NoteManager(IUserInterfaceManager parentUI, string connectionString)
//        {
//            _parentUI = parentUI;
//            //_noteRepository = new NoteRepository(connectionString);
//            _connectionString = connectionString;
//        }

//        public IUserInterfaceManager Execute()
//        {
//            Console.WriteLine("Note Menu");
//            Console.WriteLine(" 1) List Notes");
//            Console.WriteLine(" 2) Add Note");
//            Console.WriteLine(" 3) Edit Note");
//            Console.WriteLine(" 4) Remove Note");
//            Console.WriteLine(" 0) Go Back");

//            Console.Write("> ");
//            string choice = Console.ReadLine();
//            switch (choice)
//            {
//                case "1":
//                    List();
//                    return this;
//                case "2":
//                    Add();
//                    return this;
//                case "3":
//                    Edit();
//                    return this;
//                case "4":
//                    Remove();
//                    return this;
//                case "0":
//                    return _parentUI;
//                default:
//                    Console.WriteLine("Invalid Selection");
//                    return this;
//            }
//        }

//        private void List()
//        {
//            List<Note> notes = _noteRepository.GetAll();
//            foreach (Note note in notes)
//            {
//                Console.WriteLine(note);
//            }
//        }

//        private Note Choose(string prompt = null)
//        {
//            if (prompt == null)
//            {
//                prompt = "Please choose an Note:";
//            }

//            Console.WriteLine(prompt);

//            List<Note> notes = _noteRepository.GetAll();

//            for (int i = 0; i < notes.Count; i++)
//            {
//                Note note = notes[i];
//                Console.WriteLine($" {i + 1}) {note.FullName}");
//            }
//            Console.Write("> ");

//            string input = Console.ReadLine();
//            try
//            {
//                int choice = int.Parse(input);
//                return notes[choice - 1];
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Invalid Selection");
//                return null;
//            }
//        }

//        private void Add()
//        {
//            Console.WriteLine("New Note");
//            Note note = new Note();

//            Console.Write("First Name: ");
//            note.FirstName = Console.ReadLine();

//            Console.Write("Last Name: ");
//            note.LastName = Console.ReadLine();

//            Console.Write("Bio: ");
//            note.Bio = Console.ReadLine();

//            _noteRepository.Insert(note);
//        }


//        private void Remove()
//        {
//            Note noteToDelete = Choose("Which note would you like to remove?");
//            if (noteToDelete != null)
//            {
//                _noteRepository.Delete(noteToDelete.Id);
//            }
//        }
//    }
//}
