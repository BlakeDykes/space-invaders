using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteProxyNull : SpriteProxy
    {

        public SpriteProxyNull()
            : base(Sprite.Name.NullProxy)
        {
        }

        public override void Update()
        {
        }

        public override void Render()
        {
        }
    }
}
