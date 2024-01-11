using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissleStateFlying : MissleState
    {

        public MissleStateFlying()
        {
            this.StateName = MissleManager.State.MissleFlying;
        }
        public override void Handle()
        {
            MissleManager.SetState(MissleManager.State.Ready);
        }

        public override void ShootMissle()
        {
        }
    }
}
