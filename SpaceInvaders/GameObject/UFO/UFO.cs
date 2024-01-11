using Azul;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFO : Leaf
    {
        public float MoveDistance = Constants.UFO_MOVE_SPEED;
        bool Moving;

        public UFO(float _x, float _y, Azul.Color color, int directionModifier, bool moving = true)
            : base(GameObject.Name.UFO, Sprite.Name.UFO, _x,  _y, color)
        {
            this.Moving = moving;
            if(directionModifier == 1)
            {
                MoveDistance *= -1.0f;
            }
        }

        public override void Visit(MissleGroup m)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", m.GOName, this.GOName);
            GameObject pChild = (GameObject)m.GetChild();
            ColPair.Collide(pChild, this);
        }
        public override void Visit(Missle m)
        {
            //Debug.WriteLine(" {0} Collided with {1}", m.GOName, this.GOName);
            //Debug.WriteLine("------------------------");
            //Debug.WriteLine("");

            ColPair pActiveCol = ColPairManager.GetActivePair();
            pActiveCol.SetCollision(m, this);
            pActiveCol.Notify();
        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }

        public override void Update()
        {
            if (this.Moving)
            {
                this.x += this.MoveDistance;
            }
            base.Update();
        }

    }
}
