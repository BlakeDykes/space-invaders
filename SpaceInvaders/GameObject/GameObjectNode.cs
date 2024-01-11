using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameObjectNode : DLink
    {
        public bool ClearOnShipExplosion;

        public GameObject pGameObj;
        private CompositeIteratorReverse poIterator;

        public GameObjectNode(bool clearOnShipExplosion = false)
        {
            this.pGameObj = null;

            // LTN - GameObjectNode
            poIterator = new CompositeIteratorReverse();

            this.ClearOnShipExplosion = clearOnShipExplosion;
        }

        public void Set(GameObject pGO, bool clearOnShipExplosion = false)
        {
            Debug.Assert(pGO != null);
            this.pGameObj = pGO;
            this.ClearOnShipExplosion = clearOnShipExplosion;

            ResetIterator();
        }

        public void Update()
        {
            pGameObj.Update();
        }

        public void UpdateAll()
        {
            ResetIterator();
            GameObject pCur = (GameObject)poIterator.Current();
            while(poIterator.IsDone() == false)
            {
                pCur.Update();
                pCur = (GameObject)poIterator.Next();
            }
        }

        private CompositeIteratorReverse ResetIterator()
        {
            poIterator.Reset(pGameObj);
            return poIterator;
        }

        public void Clear()
        {
            ResetIterator();
            GameObject pCur = (GameObject)poIterator.Current();
            GameObject pTemp = null;
            while(poIterator.IsDone() == false && pCur != this.pGameObj)
            {
                pTemp = (GameObject)poIterator.Next();
                pCur.Remove();
                pCur = pTemp;
            }
            this.pGameObj.BaseUpdateColBox(this.pGameObj, out this.pGameObj.LeafCount);
        }

        public override void Wash()
        {
            base.Wash();
            this.pGameObj = null;
            this.ClearOnShipExplosion = false;
        }
        public override bool Compare(NodeBase pNode)
        {
            Debug.Assert(pNode != null);
            GameObjectNode pGO = (GameObjectNode)pNode;

            return (pGameObj.GOName == pGO.pGameObj.GOName);
        }
    }
}
