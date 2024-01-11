using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CommandMoveShip : Command
    {
        public Ship pShip;
        public float MoveSpeed = Constants.SHIP_MOVE_SPEED;
        public CommandMoveShip(Ship _pShip, float direction)
        {
            this.pShip = _pShip;
            this.MoveSpeed *= direction;
        }
        
        public override void Execute(float deltaTime)
        {
            this.pShip.x += this.MoveSpeed;
        }
    }
}
