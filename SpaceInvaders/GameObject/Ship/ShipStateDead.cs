using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipStateDead : ShipState
    {
        public ShipStateDead()
        {
            this.StateName = ShipManager.State.Dead;
        }

        public override void Handle(Ship pShip)
        {
        }

        public override void MoveLeft(CommandMoveShip pCommand)
        {
        }

        public override void MoveRight(CommandMoveShip pCommand)
        {
        }

        public override void ShootMissle()
        {
        }
    }
}
