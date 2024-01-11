using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class AlienBase : Leaf
    {
        public enum AlienType 
        {
            AlienGroup,
            AlienGrid,
            AlienColumn,

            Crab,
            Octo,
            Squid,
        }

        protected AlienBase(GameObject.Name _name, Sprite.Name _spriteName, float _x, float _y, Azul.Color color)
            :base(_name, _spriteName, _x, _y, color)
        {
        }

        public override void Remove()
        {
            this.poColObj.poColRect.Set(0.0f, 0.0f, 0.0f, 0.0f);
            //base.Update();

            GameObject pParent = (GameObject)this.GetParent();
            pParent.BaseUpdateColBox(pParent, out this.LeafCount);

            base.Remove();
        }
    }
}
