using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CommandMoveMissle : Command
    {
        public Missle pMissle;
        public float MissleSpeed;

        public CommandMoveMissle(Missle _pMissle)
        {
            this.pMissle = _pMissle;
            this.MissleSpeed = Constants.MISSLE_SPEED;
        }

        public override void Execute(float deltaTime)
        {
            this.pMissle.y += MissleSpeed;

            TimerManager.Add(TimerEvent.Name.MoveMissle, deltaTime, this);
        }
    }
}
