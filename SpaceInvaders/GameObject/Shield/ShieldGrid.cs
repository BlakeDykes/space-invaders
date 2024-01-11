using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldGrid : Composite
    {
        public ShieldGrid(Name _name, float _x, float _y) 
            : base(_name, Sprite.Name.NullProxy, _x, _y, Constants.TRANSPARENT)
        {
        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }

        public override void Visit(MissleGroup m)
        {
            GameObject pChild = (GameObject)this.GetChild();
            ColPair.Collide(m, pChild);
        }

        public override void Visit(BombGroup b)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", b.GOName, this.GOName);
            GameObject pChild = (GameObject)this.GetChild();
            ColPair.Collide(b, pChild);
        }

        public override void Update()
        {
            BaseUpdateColBox(this, out this.LeafCount);
            base.Update();
        }
    }
}
