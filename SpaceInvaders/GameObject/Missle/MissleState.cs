using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public abstract class MissleState : SLink
    {
        public MissleManager.State StateName;

        public abstract void Handle();

        public abstract void ShootMissle();
    }
}
