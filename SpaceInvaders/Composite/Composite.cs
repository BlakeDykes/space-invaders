using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Composite : GameObject
    {
        DLinkManager poDLinkMan;

        public Composite(GameObject.Name _name, Sprite.Name _spriteName, float _x, float _y, Azul.Color pColor)
            : base(_name, _spriteName, _x, _y, pColor)
        {
            // LTN - Composite
            this.poDLinkMan = new DLinkManager();
            this.ComponentType = Type.Composite;
        }

        public Composite(GameObject.Name _name, Sprite.Name _proxyName)
            : base(_name, _proxyName, Constants.TRANSPARENT)
        {
            // LTN - Composite
            this.poDLinkMan = new DLinkManager();
        }


        public override void Add(Component pComp)
        {
            Debug.Assert(pComp != null);
            poDLinkMan.Add(pComp);
            pComp.pParent = this;
        }

        public override void Remove(Component pComp)
        {
            Debug.Assert(pComp != null);
            poDLinkMan.Remove(pComp);

        }

        public override Component GetChild()
        {
            return (Component)poDLinkMan.GetFirst();
        }

        protected IteratorBase GetIterator()
        {
            return this.poDLinkMan.GetIterator();
        }
    }
}
