using System;

namespace TabloidCLI.UserInterfaceManagers
{
    class BackgroundColorManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        public BackgroundColorManager(IUserInterfaceManager parentUI)
        {
            _parentUI = parentUI;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Background Color Options");
            Console.WriteLine(" 1) Black");
            Console.WriteLine(" 2) White");
            Console.WriteLine(" 3) Grey");
            Console.WriteLine(" 4) Red");
            Console.WriteLine(" 5) Blue");
            Console.WriteLine(" 0) Go Back");


            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    return this;
                case "2":
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    return this;
                case "3":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                    return this;
                case "4":
                    Console.BackgroundColor = ConsoleColor.Red;
                    return this;
                case "5":
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}
