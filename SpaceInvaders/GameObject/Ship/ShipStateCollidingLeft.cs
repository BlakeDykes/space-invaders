using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipStateCollidingLeft : ShipState
    {

        public ShipStateCollidingLeft()
        {
            this.StateName = ShipManager.State.CollidingLeft;
        }

        public override void Handle(Ship pShip)
        {
            pShip.SetState(ShipManager.State.Ready);
        }

        public override void MoveLeft(CommandMoveShip pCommand)
        {
        }

        public override void MoveRight(CommandMoveShip pCommand)
        {
            TimerManager.Add(TimerEvent.Name.MoveShipRight, 0.00001f, pCommand);
            this.Handle(ShipManager.GetShip());
        }

        public override void ShootMissle()
        {
            MissleManager.ShootMissle();
        }
    }
}
