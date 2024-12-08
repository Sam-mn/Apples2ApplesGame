using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesGame.notUsed
{
    public abstract class ISubject
    {
        public abstract void AttachObserver(IGameObserver observer);
        public abstract void NotifyObservers(string message);
    }
}
