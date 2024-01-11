using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GhostManager : ManagerBase
    {
        private static GhostManager instance = null;
        private GameObjectNode pCompNode = null;
        private GameObjectNull poGameObject;
        private GhostManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved) 
            : base(active, reserved, deltaGrow, initialReserved)
        {
            this.pCompNode = new GameObjectNode();
            this.poGameObject = new GameObjectNull();
            this.pCompNode.pGameObj = this.poGameObject;
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            Debug.Assert(instance == null);

            if(instance == null)
            {
                instance = new GhostManager(active, reserved, deltaGrow, initialReserved);
            }
        }

        public static GameObjectNode Attach(GameObject gameObject)
        {
            GhostManager inst = GhostManager.GetInstance();
            GameObjectNode pNode = (GameObjectNode)inst.BaseAdd();

            gameObject.isGhost = true;
            pNode.Set(gameObject);
            return pNode;
        }

        public static GameObjectNode Find(GameObject.Name name)
        {
            GhostManager inst = GhostManager.GetInstance();

            inst.pCompNode.pGameObj.GOName = name;

            return (GameObjectNode)inst.BaseFind(inst.pCompNode);
        }

        public static void Remove(GameObjectNode pNode)
        {
            Debug.Assert(pNode != null);
            GhostManager inst = GhostManager.GetInstance();

            inst.BaseRemove(pNode);
        }

        protected override NodeBase DerivedCreateNode()
        {
            return new GameObjectNode();
        }

        private static GhostManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }
    }
}
