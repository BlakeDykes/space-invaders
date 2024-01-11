using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ShipState : SLink
    {
        // State
        public ShipManager.State StateName;

        public abstract void Handle(Ship pShip);

        // Strategy
        public abstract void MoveLeft(CommandMoveShip pCommand);
        public abstract void MoveRight(CommandMoveShip pCommand);
        public abstract void ShootMissle();
    }
}
