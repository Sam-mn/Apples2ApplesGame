using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame.commands
{
    // The Command interface declares a method for executing a command
    internal interface ICommand
    {
        void Execute();
    }
}
