using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBoxProxyManager : ManagerBase
    {

        private static SpriteBoxProxyManager instance = null;
        private SpriteBoxProxy pCompSB;

        private SpriteBoxProxyManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
            : base(active, reserved, deltaGrow, initialReserved)
        {
            // LTN - SpriteBoxProxyManager
            pCompSB = new SpriteBoxProxy();
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            Debug.Assert(active != null);
            Debug.Assert(reserved != null);
            Debug.Assert(deltaGrow != 0);

            Debug.Assert(instance == null);

            if (instance == null)
            {
                // LTN - the process
                instance = new SpriteBoxProxyManager(active, reserved, deltaGrow, initialReserved);
            }
        }

        public static SpriteBoxProxy Add(SpriteBox.Name name, float x, float y, float width, float height)
        {
            SpriteBoxProxyManager inst = SpriteBoxProxyManager.GetInstance();
            Debug.Assert(inst != null);

            SpriteBoxProxy pSBP = (SpriteBoxProxy)inst.BaseAdd();
            Debug.Assert(pSBP != null);

            pSBP.Set(name, x, y, width, height);

            return pSBP;
        }

        public static SpriteBoxProxy Add(SpriteBox.Name name)
        {
            SpriteBoxProxyManager inst = SpriteBoxProxyManager.GetInstance();
            Debug.Assert(inst != null);

            SpriteBoxProxy pSBP = (SpriteBoxProxy)inst.BaseAdd();
            Debug.Assert(pSBP != null);

            pSBP.Set(name, 0.0f, 0.0f, 0.0f, 0.0f);

            return pSBP;
        }

        public static SpriteBoxProxy Remove(SpriteBoxProxy pSpriteProxy)
        {
            SpriteBoxProxyManager inst = SpriteBoxProxyManager.GetInstance();
            Debug.Assert(inst != null);

            return (SpriteBoxProxy)inst.BaseRemove(pSpriteProxy);
        }


        private static SpriteBoxProxyManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        protected override NodeBase DerivedCreateNode()
        {
            // LTN - SpriteBoxProxyManager
            return new SpriteBoxProxy();
        }
    }
}
