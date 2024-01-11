using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CommandDropBomb : Command
    {
        public override void Execute(float deltaTime)
        {
            BombManager.ActivateBomb();

            TimerManager.Add(TimerEvent.Name.DropBomb, BombManager.GetNextDrop(), this);
        }
    }
}
