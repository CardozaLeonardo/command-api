using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id = 1, Line = "sudo apt-get install git", HowTo = "Install Git",
                    Platform = "Unix"},
                new Command{Id = 2, Line = "sudo apt-get install git", HowTo = "Install Git",
                    Platform = "Unix"},
                new Command{Id = 3, Line = "sudo apt-get install git", HowTo = "Install Git",
                    Platform = "Unix"}
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id = 1, Line = "sudo apt-get install git", HowTo = "Install Git",
                Platform = "Unix"};
            //command.Id = 1;
            //command.Line = "sudo apt-get install git";
            //command.HowTo = "Install Git";
            //command.Platform = "Unix";

            //throw new System.NotImplementedException();
        }

        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}