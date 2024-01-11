using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienGrid : Composite
    {
        public bool DirectionSwitched;
        public int DirectionModifier;
        public int AlienCount;
        public int ColumnCount;

        public AlienGrid()
            : base(GameObject.Name.AlienGrid, Sprite.Name.NullProxy)
        {
            this.DirectionModifier = 1;
            this.ColumnCount = 0;
        }

        public override void Update()
        {
            BaseUpdateColBox(this, out this.LeafCount);
            base.Update();
        }

        public override void Add(Component pComp)
        {
            Debug.Assert(pComp != null);
            ColumnCount++;
            base.Add(pComp);
        }

        public override void Remove(Component pComp)
        {
            Debug.Assert(pComp != null);
            ColumnCount--;
            base.Remove(pComp);
        }

        public int GetColumnCount()
        {
            return this.ColumnCount;
        }

        public override void Visit(MissleGroup m)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", m.GOName, this.GOName);
            GameObject pChild = (GameObject)this.GetChild();
            ColPair.Collide(m, pChild);
        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }
    }
}
