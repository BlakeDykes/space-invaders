using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissleStateMissleReady : MissleState
    {

        public MissleStateMissleReady()
        {
            this.StateName = MissleManager.State.Ready;
        }

        public override void Handle()
        {
            MissleManager.SetState(MissleManager.State.MissleFlying);
        }

        public override void ShootMissle()
        {
            MissleManager.ActivateMissle();
            SoundManager.PlaySound(Sound.Name.Shoot);
            Handle();
        }
    }
}
