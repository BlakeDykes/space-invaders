using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Ship : ShipBase
    {
        private ShipState shipState;
        private CommandMoveShip MoveLeftCommand;
        private CommandMoveShip MoveRightCommand;
        private CommandShootMissle ShootMissleCommand;
        private bool MovedRight;
        private bool MovedLeft;

        public Ship(GameObject.Name _name, Sprite.Name _spriteName, float _x, float _y, Azul.Color pColor)
            : base(_name, _spriteName, _x, _y, ShipBase.Category.Ship, pColor)
        {
            this.x = _x;
            this.y = _y;

            this.shipState = null;

            this.MoveLeftCommand = new CommandMoveShip(this, -1.0f);
            this.MoveRightCommand = new CommandMoveShip(this, 1.0f);
            this.ShootMissleCommand = new CommandShootMissle();

            this.MovedRight = false;
            this.MovedLeft = false;
        }

        public override void Update()
        {
            this.MovedRight = false;
            this.MovedLeft = false;
            base.Update();
        }

        public override void Remove()
        {
            ShipManager.RemoveShip();
            base.Remove();
        }


        public void MoveRight()
        {
            if(this.MovedRight == false)
            {
                this.shipState.MoveRight(this.MoveRightCommand);
                this.MovedRight = true;
            }
        }

        public void MoveLeft()
        {
            if (this.MovedLeft == false)
            {
                this.shipState.MoveLeft(this.MoveLeftCommand);
                this.MovedLeft = true;
            }
        }

        public void SetCommandMissle(Missle _pMissle)
        {
            this.ShootMissleCommand.SetMissle(_pMissle);
        }

        public void ShootMissle()
        {
            this.shipState.ShootMissle();
        }

        public void SetState(ShipManager.State inState)
        {
            this.shipState = ShipManager.GetState(inState);
        }

        public void Handle()
        {
            this.shipState.Handle(this);
        }

        public ShipState GetState()
        {
            return this.shipState;
        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }
    }
}
