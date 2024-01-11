using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Leaf : GameObject
    {
        public Leaf(GameObject.Name _name, Sprite.Name _spriteName, float _x, float _y, Azul.Color pColor)
            : base(_name, _spriteName, _x, _y, pColor)
        {
            this.ComponentType = Type.Leaf;
        }
        public Leaf(GameObject.Name _name, Sprite.Name _spriteName, float _x, float _y, float _width, float _height, Azul.Color pColor)
            : base(_name, _spriteName, _x, _y, _width, _height, pColor)
        {
            this.ComponentType = Type.Leaf;
        }


        public override void Add(Component pComp)
        {
            // Do not implement
        }

    }
}
