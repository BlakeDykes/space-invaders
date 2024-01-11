using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Command 
    {
        public abstract void Execute(float deltaTime);
    }
}
