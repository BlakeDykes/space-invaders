using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBatch : DLink
    {
        float Priority;
        public SpriteBatch.Name BatchName;
        public SpriteNodeManager pSNodeMan;
        private bool DrawEnable;

        public enum Name
        {
            Ships,
            Aliens,
            Bombs,
            Walls,
            Boxes,
            Text,
            Shields,
            Explosions,

            LifeMarkers_Player_1,
            LifeMarkers_Player_2,

            CollisionBoxes,

            Uninitialized
        }

        public SpriteBatch()
        {
            this.BatchName = Name.Uninitialized;

            // LTN - SpriteBatch
            pSNodeMan = new SpriteNodeManager(Name.Uninitialized);
            DrawEnable = true;
        }

        public void SetPriority(float priority)
        {
            Debug.Assert(priority != 0);
            this.Priority = priority;
        }

        public void Set(float priority, SpriteBatch.Name name, int deltaGrow, int initialReserved)
        {
            this.Priority = priority;
            this.BatchName = name;

            // LTN - SpriteBatch
            this.pSNodeMan = new SpriteNodeManager(name, deltaGrow, initialReserved);
        }

        public void Clear()
        {
            this.pSNodeMan.Clear();
        }

        // Refactor all of these Attach() methods to be OOP friendly
        public void Attach(GameObject pGameObj)
        {
            Debug.Assert(pGameObj != null);
            pSNodeMan.Attach(pGameObj.pSpriteProxy);
        }

        public void Attach(SpriteBoxProxy pSpriteProxy)
        {
            Debug.Assert(pSpriteProxy != null);
            pSNodeMan.Attach(pSpriteProxy);
        }

        public void Attach(SpriteProxy pSpriteProxy)
        {
            Debug.Assert(pSpriteProxy != null);
            pSNodeMan.Attach(pSpriteProxy);
        }


        public void Attach(Sprite.Name name)
        {
            SpriteNode pSN = (SpriteNode)pSNodeMan.BaseAdd();
            pSN.Set(name, pSNodeMan);
        }

        public void Attach(SpriteBox.Name name)
        {
            SpriteNode pSN = (SpriteNode)pSNodeMan.BaseAdd();
            pSN.Set(name, pSNodeMan);
        }

        public void Attach(Font.Name name)
        {
            SpriteNode pSN = (SpriteNode)pSNodeMan.BaseAdd();
            pSN.Set(name, pSNodeMan);
        }

        public void SetDrawEnable(bool status)
        {
            this.DrawEnable = status;
        }

        public bool GetDrawEnable()
        {
            return this.DrawEnable;
        }

        public void RenderAll()
        {
            this.pSNodeMan.RenderAll();
        }

        public void UpdateAll()
        {
            this.pSNodeMan.UpdateAll();
        }

        public void DumpStats()
        {
            this.pSNodeMan.DumpStats();
        }

        // returns true if this.Priority > passed priority
        public override PriorityCompResult ComparePriority(float priority)
        {
            return this.Priority > priority ? PriorityCompResult.GREATER_THAN : PriorityCompResult.LESS_THAN;
        }

        public override bool Compare(NodeBase pNode)
        {
            SpriteBatch pBatch = (SpriteBatch)pNode;
            return (this.BatchName == pBatch.BatchName);
        }
    }
}
