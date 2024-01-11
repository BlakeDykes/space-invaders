using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipGroup : Composite
    {
        public ShipGroup()
            : base(Name.ShipGroup, Sprite.Name.NullProxy, 0.0f, 0.0f, Constants.TRANSPARENT)
        {
        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }

        public override void Update()
        {
            base.BaseUpdateColBox(this, out this.LeafCount);
            base.Update();
        }

        public override void Visit(BombGroup b)
        {
            GameObject pChild = (GameObject)this.GetChild();
            ColPair.Collide(b, pChild);
        }
    }
}
