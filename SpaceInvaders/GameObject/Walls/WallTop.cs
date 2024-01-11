using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallTop : WallBase
    {
        public WallTop(GameObject.Name _name, Sprite.Name _spriteName, float _x, float _y, float _width, float _height, Azul.Color pColor) 
            : base(_name, _spriteName, _x, _y, _width, _height, pColor)
        {
            this.wallType = WallType.Top;
        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
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

    }
}
