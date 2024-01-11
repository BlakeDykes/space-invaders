using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CommandShootMissle : Command
    {
        public Missle pMissle;
        public CommandShootMissle()
        {
            pMissle = null;
        }

        public void SetMissle(Missle _pMissle)
        {
            this.pMissle = _pMissle;
        }

        public override void Execute(float deltaTime)
        {
        }
    }
}
