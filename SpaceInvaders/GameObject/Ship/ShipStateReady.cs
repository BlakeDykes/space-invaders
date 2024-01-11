using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipStateReady : ShipState
    {

        public ShipStateReady()
        {
            this.StateName = ShipManager.State.Ready;
        }

        public override void Handle(Ship pShip)
        {
            pShip.SetState(ShipManager.State.Dead);
        }

        public override void MoveLeft(CommandMoveShip pCommand)
        {
            TimerManager.Add(TimerEvent.Name.MoveShipLeft, 0.00001f, pCommand);
        }

        public override void MoveRight(CommandMoveShip pCommand)
        {
            TimerManager.Add(TimerEvent.Name.MoveShipRight, 0.00001f, pCommand);
        }

        public override void ShootMissle()
        {
            MissleManager.ShootMissle();
        }
    }
}
