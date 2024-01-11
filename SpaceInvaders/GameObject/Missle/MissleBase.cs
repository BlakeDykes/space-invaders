using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class MissleBase : Leaf
    {
        protected MissleBase(GameObject.Name _name, Sprite.Name _spriteName, float _x, float _y, Azul.Color pColor) 
            : base(_name, _spriteName, _x, _y, pColor)
        {
        }
    }
}
