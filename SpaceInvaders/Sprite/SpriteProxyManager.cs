using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteProxyManager : ManagerBase
    {
        private static SpriteProxyManager instance = null;
        private SpriteProxy pCompSprite;

        private SpriteProxyManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        : base(active, reserved, deltaGrow, initialReserved)
        {
            // LTN - SpriteProxyManager
            pCompSprite = new SpriteProxy();
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            Debug.Assert(active != null);
            Debug.Assert(reserved != null);
            Debug.Assert(deltaGrow != 0);

            Debug.Assert(instance == null);

            if (instance == null)
            {
                // LTN - SpriteProxyManager
                instance = new SpriteProxyManager(active, reserved, deltaGrow, initialReserved);
            }

            Add(Sprite.Name.NullProxy, 0.0f, 0.0f);
        }

        public static SpriteProxy Add(Sprite.Name name, float x, float y)
        {
            SpriteProxyManager inst = SpriteProxyManager.GetInstance();
            Debug.Assert(inst != null);

            SpriteProxy pSP = (SpriteProxy)inst.BaseAdd();
            Debug.Assert(pSP != null);

            pSP.Set(name, x, y);

            return pSP;
        }

        public static SpriteProxy Add(Sprite.Name name)
        {
            SpriteProxyManager inst = SpriteProxyManager.GetInstance();
            Debug.Assert(inst != null);

            SpriteProxy pSP = (SpriteProxy)inst.BaseAdd();
            Debug.Assert(pSP != null);

            pSP.Set(name, 0.0f, 0.0f);

            return pSP;
        }

        public static SpriteProxy Find(Sprite.Name name)
        {
            Debug.Assert(name != Sprite.Name.Uninitialized);

            SpriteProxyManager inst = SpriteProxyManager.GetInstance();
            Debug.Assert(inst != null);

            inst.pCompSprite.SpriteName = name;

            return (SpriteProxy)inst.BaseFind(inst.pCompSprite);
        }

        public static SpriteProxy Remove(SpriteProxy pSpriteProxy)
        {
            SpriteProxyManager inst = SpriteProxyManager.GetInstance();
            Debug.Assert(inst != null);

            return (SpriteProxy)inst.BaseRemove(pSpriteProxy);
        }

        private static SpriteProxyManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        protected override NodeBase DerivedCreateNode()
        {
            // LTN - SpriteProxyManager
            return new SpriteProxy();
        }
    }
}
