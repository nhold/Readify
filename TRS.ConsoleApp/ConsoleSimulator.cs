using System;
using System.Collections.Generic;
using TRS.ConsoleApp.Commands;
using TRS.Library;

namespace TRS.ConsoleApp
{
    public class ConsoleSimulator
    {
        public CommandLibrary commandLibrary;
        private readonly ToyRobot toyRobot;
        private readonly Map map;
        private bool isRunning;

        public ConsoleSimulator()
        {
            commandLibrary = new CommandLibrary();
            toyRobot = new ToyRobot(); ;
            map = new Map(6, 6);
            isRunning = true;

            // Bind the ToyRobot API
            commandLibrary.Register(new ActionCommand("left", toyRobot.Left));
            commandLibrary.Register(new ActionCommand("right", toyRobot.Right));
            commandLibrary.Register(new ActionCommand("move", toyRobot.Move));
            commandLibrary.Register(new OverloadedCommand("place",
                new List<ICommand>()
                {
                    new ArgumentCommand<int, int>("place", (x,y) => toyRobot.Place(x,y)),
                    new ArgumentCommand<int, int, Direction>("place", (x,y,dir) => toyRobot.Place(map, x, y, dir))
                }));

            // Bind the Simulator API
            commandLibrary.Register(new ActionCommand("quit", Quit));
            commandLibrary.Register(new ActionCommand("report", Report));
        }

        public void Report()
        {
            Console.WriteLine($"Output: {toyRobot.Position.x},{toyRobot.Position.y},{toyRobot.Direction}");
        }

        public void Quit()
        {
            isRunning = false;
        }

        public void Run()
        {
            while (isRunning)
            {
                UserInput userInput = UserInput.ExtractUserInput(Console.ReadLine());

                if (userInput.IsValid)
                {
                    commandLibrary.Execute(userInput);
                }
            }
        }
    }
}