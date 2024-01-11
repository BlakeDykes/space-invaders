using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteNodeManager : ManagerBase
    {
        private SpriteNode pCompareNode;
        private SpriteBatch.Name BatchName;

        public SpriteNodeManager(SpriteBatch.Name name, int deltaGrow = 3, int initialReserved = 3)
        // LTN - SpriteNodeManager
        // LTN - SpriteNodeManager
        : base(new DLinkManager(), new DLinkManager(), deltaGrow, initialReserved)
        {
            this.BatchName = name;

            // LTN - SpriteNodeManager
            this.pCompareNode = new SpriteNode();
        }

        public SpriteNode Attach(Sprite.Name name)
        {
            SpriteNode pSprite = (SpriteNode)this.BaseAdd();
            pSprite.Set(name, this);
            return pSprite;
        }

        public SpriteNode Attach(SpriteBox.Name name)
        {
            SpriteNode pSprite = (SpriteNode)this.BaseAdd();
            pSprite.Set(name, this);
            return pSprite;
        }

        public SpriteNode Attach(SpriteProxy pProxy)
        {
            SpriteNode pSprite = (SpriteNode)this.BaseAdd();
            pSprite.Set(pProxy, this);
            return pSprite;
        }

        public SpriteNode Attach(SpriteBoxProxy pProxy)
        {
            SpriteNode pSprite = (SpriteNode)this.BaseAdd();
            pSprite.Set(pProxy, this);
            return pSprite;
        }

        public void Set(SpriteBatch.Name _name, int deltaGrow, int initialReserved)
        {
            this.BatchName = _name;

            Debug.Assert(deltaGrow != 0);

            this.SetReserve(deltaGrow, initialReserved);
        }

        public void Clear()
        {
            BaseClear();
        }

        public void UpdateAll()
        {
            DLinkIterator it = (DLinkIterator)this.poActive.GetIterator();
            Debug.Assert(it != null);

            SpriteNode pSprite = (SpriteNode)it.First();
            while (it.IsDone() != true)
            {
                pSprite.pSpriteBase.Update();
                pSprite = (SpriteNode)it.Next();
            }
        }

        public void RenderAll()
        {

            DLinkIterator it = (DLinkIterator)this.poActive.GetIterator();
            Debug.Assert(it != null);

            SpriteNode pSprite = (SpriteNode)it.First();
            while (it.IsDone() != true)
            {
                pSprite.pSpriteBase.Render();
                pSprite = (SpriteNode)it.Next();
            }
        }

        protected override NodeBase DerivedCreateNode()
        {
            // LTN - SpriteNodeManager
            return new SpriteNode();
        }

        public void DumpStats()
        {
            Debug.WriteLine("{0} NodeManager - ", this.BatchName);
            this.BaseDumpStats();
        }


    }
}
