using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverAlienWall : Observer
    {
        AlienGrid pAlienGrid;

        public ObserverAlienWall()
        {
            this.pAlienGrid = (AlienGrid)GameObjectNodeManager.Find(GameObject.Name.AlienGrid);
        }
        public override void Notify()
        {
            if(pAlienGrid.DirectionSwitched == false)
            {
                this.pAlienGrid.DirectionModifier = -this.pAlienGrid.DirectionModifier;
                pAlienGrid.DirectionSwitched = true;
            }
        }
    }
}
