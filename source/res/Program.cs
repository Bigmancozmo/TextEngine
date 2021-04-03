// TextEngine is written by BigmancozmoPlayz

using System;
using System.IO;

namespace full_game
{
    class Program
    {
        public void restart()
        {
            Console.Clear();
            var prg = new Program();
            Console.WriteLine("Welcome to TextEngine");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("Create, Open, or Exit: ");
            string task = Console.ReadLine();
            prg.computePrompt(task);
        }
        public void waitForKeyPress()
        {
            Console.WriteLine("Press any key to continue.");
            // Wait for a keypress before exiting the function.
            Console.ReadKey();
        }
        public void validateProjectBeforeOpen()
        {
            // Ask user for the project name
            Console.WriteLine("Project name:");
            string projname = Console.ReadLine();
            // Find the current user's desktop
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = desktop + "/" + projname;
            // Check if project is valid
            if (Directory.Exists(path))
            {
                Console.WriteLine("Found project folder");
                if (Directory.Exists(path + "/Assets"))
                {
                    Console.WriteLine("Found 'Assets' folder");
                    if (File.Exists(path + "/accessible.txt"))
                    {
                        // If project is valid, open it
                        Console.WriteLine("Found validation file");
                        Console.WriteLine("Opening '" + projname + "'");
                    }
                    else
                    {
                        Console.WriteLine("Project '" + projname + "' is not made with TextEngine.");
                    }
                }
                else
                {
                    Console.WriteLine("Project '" + projname + "' is not made with TextEngine.");
                }
            }
            else
            {
                Console.WriteLine("Project '" + projname + "' does not exist.");
            }
            var prg = new Program();
            prg.waitForKeyPress();
            prg.restart();
        }
        public void addFile(string name, string path, string projname)
        {
            File.Create(path + "/" + projname + "/" + name);
        }
        public void addFolder(string name, string path, string projname)
        {
            Directory.CreateDirectory(path + "/" + projname + name);
        }
        public void computePrompt(string p)
        {
            var prg = new Program();
            // Run task
            if (p == "open")
            {
                prg.validateProjectBeforeOpen();
            }
            else
            {
                if (p == "create")
                {
                    Console.WriteLine("Project Name: ");
                    string projname = Console.ReadLine();
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    Directory.CreateDirectory(path + "/" + projname);
                    prg.addFolder("/Assets/Scenes", path, projname);
                    prg.addFolder("/Assets/Scripts", path, projname);
                    prg.addFile("accessible.txt", path, projname);
                    Console.WriteLine("WARNING!!!");
                    Console.WriteLine("KEEP this file on the desktop if you want it to be accessable by the program.");
                    Console.WriteLine("Re-open the application to open your project");
                    prg.waitForKeyPress();
                    prg.restart();
                }
                else
                {
                    if (p == "exit")
                    {
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("'" + p + "' is not a valid command. If you did type a valid command, make sure it has no capital letters.");
                        prg.waitForKeyPress();
                        prg.restart();
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            var prg = new Program();
            prg.restart();
        }
    }
}