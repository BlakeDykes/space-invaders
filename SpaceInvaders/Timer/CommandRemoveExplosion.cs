using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CommandRemoveExplosion : Command
    {
        private SpriteProxy pExplosion;

        public CommandRemoveExplosion(SpriteProxy _pExplosion)
        {
            this.pExplosion = _pExplosion;
        }

        public override void Execute(float deltaTime)
        {
            this.pExplosion.Remove();
        }
    }
}
