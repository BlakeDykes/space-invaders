using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Observer : SLink
    {
        public Subject pSubject;
        public abstract void Notify();

        public virtual void Execute() 
        { 
        }
    }
}
