using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectNodeManager : ManagerBase
    {
        private static GameObjectNodeManager instance = null;
        private GameObjectNode pCompGO;

        private bool ShipExploding;

        private GameObjectNodeManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        : base(active, reserved, deltaGrow, initialReserved)
        {
            // LTN - GameObjectNodeManager
            pCompGO = new GameObjectNode();
            pCompGO.Set(new GameObjectNull());
            ShipExploding = false;
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
                instance = new GameObjectNodeManager(active, reserved, deltaGrow, initialReserved);
            }
        }

        public static GameObjectNode Attach(GameObject pGameObject, bool clearOnShipExplosion = false)
        {
            GameObjectNodeManager inst = GameObjectNodeManager.GetInstance();
            Debug.Assert(inst != null);

            GameObjectNode pNode = (GameObjectNode)inst.BaseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(pGameObject, clearOnShipExplosion);
            return pNode;
        }

        public static GameObjectNode Remove(GameObjectNode pGameObject)
        {
            Debug.Assert(pGameObject != null);

            GameObjectNodeManager inst = GameObjectNodeManager.GetInstance();
            Debug.Assert(inst != null);

            GameObjectNode pNode = (GameObjectNode)inst.BaseRemove(pGameObject);
            Debug.Assert(pNode != null);

            return pNode;
        }

        public static void Remove(GameObject pGameObject)
        {
            Debug.Assert(pGameObject != null);
            Debug.Assert(pGameObject.GetChild() == null);
            GameObjectNodeManager inst = GameObjectNodeManager.GetInstance();

            GameObject pSafetyNode = pGameObject;

            GameObject pTemp = pGameObject;
            GameObject pRoot = null;
            // Find tree root
            while(pTemp != null)
            {
                pRoot = pTemp;
                pTemp = (GameObject)pRoot.GetParent();
            }

            IteratorBase pIt = inst.BaseGetIterator();
            GameObjectNode pCurNode = (GameObjectNode)pIt.First();

            // Walk active list looking for root
            while (pIt.IsDone() != true)
            {
                if(pCurNode.pGameObj == pRoot)
                {
                    break;
                }
                pCurNode = (GameObjectNode)pIt.Next();
            }

            Debug.Assert(pCurNode != null);
            Debug.Assert(pCurNode.pGameObj != null);
            GameObject pParent = (GameObject)pGameObject.GetParent();

            pParent.Remove(pGameObject);

        }

        public static GameObject Find(GameObject.Name name)
        {
            GameObjectNodeManager inst = GameObjectNodeManager.GetInstance();
            Debug.Assert(inst != null);

            inst.pCompGO.pGameObj.GOName = name;

            GameObjectNode pNode = (GameObjectNode)inst.BaseFind(inst.pCompGO);

            return pNode.pGameObj;

        }

        public static void UpdateAll()
        {
            GameObjectNodeManager inst = GameObjectNodeManager.GetInstance();
            Debug.Assert(inst != null);

            if(inst.ShipExploding == true)
            {
                inst.RemoveOnShipExplosion();
            }

            IteratorBase it = inst.BaseGetIterator();
            Debug.Assert(it != null);

            GameObjectNode pNode = (GameObjectNode)it.First();

            while(it.IsDone() != true)
            {
                pNode.UpdateAll();
                pNode = (GameObjectNode)it.Next();
            }
        }

        public static void Clear()
        {
            GameObjectNodeManager inst = GameObjectNodeManager.GetInstance();
            Debug.Assert(inst != null);

            IteratorBase it = inst.BaseGetIterator();
            Debug.Assert(it != null);

            GameObjectNode pNode = (GameObjectNode)it.First();

            while (it.IsDone() != true)
            {
                pNode.Clear();
                pNode = (GameObjectNode)it.Next();
            }
        }

        private void RemoveOnShipExplosion()
        {
            GameObjectNodeManager inst = GameObjectNodeManager.GetInstance();
            Debug.Assert(inst != null);

            IteratorBase it = (IteratorBase)inst.BaseGetIterator();
            Debug.Assert(it != null);

            GameObjectNode pNode = (GameObjectNode)it.First();

            while (it.IsDone() == false)
            {
                if(pNode.ClearOnShipExplosion == true && pNode.pGameObj.isGhost == false)
                {
                    pNode.Clear();
                }
                pNode = (GameObjectNode)it.Next();
            }
        }

        public static void SetShipExploding(bool isExploding)
        {
            GameObjectNodeManager inst = GameObjectNodeManager.GetInstance();

            inst.ShipExploding = isExploding;
        }

        private static GameObjectNodeManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        protected override NodeBase DerivedCreateNode()
        {
            // LTN - GameObjectNodeManager
            return new GameObjectNode();
        }
    }
}
