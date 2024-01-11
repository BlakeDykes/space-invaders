using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipStateCollidingRight : ShipState
    {
        public ShipStateCollidingRight()
        {
            this.StateName = ShipManager.State.CollidingRight;
        }

        public override void Handle(Ship pShip)
        {
            pShip.SetState(ShipManager.State.Ready);
        }

        public override void MoveLeft(CommandMoveShip pCommand)
        {
            TimerManager.Add(TimerEvent.Name.MoveShipLeft, 0.00001f, pCommand);
            this.Handle(ShipManager.GetShip());
        }

        public override void MoveRight(CommandMoveShip pCommand)
        {
        }

        public override void ShootMissle()
        {
            MissleManager.ShootMissle();
        }
    }
}
