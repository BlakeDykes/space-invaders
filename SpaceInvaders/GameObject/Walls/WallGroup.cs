using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallGroup : Composite
    {
        public WallGroup(GameObject.Name _name, Sprite.Name _spriteName, float _x, float _y) 
            : base(_name, _spriteName, _x, _y, Constants.TRANSPARENT)
        {
        }

        public override void Update()
        {
            base.BaseUpdateColBox(this, out this.LeafCount);
            base.Update();
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

        public override void Visit(UFOGroup u)
        {
            GameObject pChild = (GameObject)this.GetChild();
            ColPair.Collide(u, pChild);
        }

        public override void Visit(ShipGroup s)
        {
            GameObject pChild = (GameObject)this.GetChild();
            ColPair.Collide(s, pChild);
        }

        public override void Visit(BombGroup b)
        {
            GameObject pChild = (GameObject)this.GetChild();
            ColPair.Collide(b, pChild);
        }

        public override void Visit(AlienGrid w)
        {
            GameObject pChild = (GameObject)this.GetChild();
            ColPair.Collide(w, pChild);
        }
    }
}
