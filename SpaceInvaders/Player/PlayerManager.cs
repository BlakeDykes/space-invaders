using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class PlayerManager
    {
        private static PlayerManager instance = null;

        private Player poHead;
        private Player pCurPlayer;
        private Player pCompPlayer;

        private PlayerManager()
        {
            this.poHead = null;
            this.pCompPlayer = new Player(Player.PlayerName.Uninitialized);
        }

        public static void Create()
        {
            if(instance == null)
            {
                instance = new PlayerManager();
            }
            else
            {
                PlayerManager inst = PlayerManager.GetInstance();

                Player pPlayer = inst.pCurPlayer;

                while(pPlayer != null)
                {
                    pPlayer.Reset();
                    pPlayer = (Player)pPlayer.pNext;
                }
            }
        }

        public static void Attach(Player p)
        {
            PlayerManager inst = PlayerManager.GetInstance();

            if(PlayerManager.Find(p.Id) != null)
            {
                return;
            }

            if(inst.poHead == null)
            {
                inst.poHead = p;
                inst.pCurPlayer = p;
            }
            else
            {
                p.pNext = inst.poHead;
                inst.poHead = p;
            }

            p.GenerateLives(Constants.STARTING_LIFE_COUNT);
        }

        public static Player Find(Player.PlayerName name)
        {
            PlayerManager inst = PlayerManager.GetInstance();

            Player pCur = inst.poHead;
            inst.pCompPlayer.Id = name;

            while (pCur != null)
            {
                if (pCur.Compare(inst.pCompPlayer))
                {
                    return pCur;
                }
            }

            return null;
        }

        public static Player GetCurrentPlayer()
        {
            PlayerManager inst = PlayerManager.GetInstance();

            return inst.pCurPlayer;
        }

        // TODO: Refactor for multiplayer
        public static int GetLivesLeft()
        {
            PlayerManager inst = PlayerManager.GetInstance();

            return inst.pCurPlayer.Lives;
        }

        public static void RemoveLife()
        {
            PlayerManager inst = PlayerManager.GetInstance();

            inst.pCurPlayer.RemoveLife();
        }

        public static void SetCurrent(Player.PlayerName name)
        {
            PlayerManager inst = PlayerManager.GetInstance();
            Debug.Assert(inst.poHead != null);

            inst.pCurPlayer = PlayerManager.Find(name);
        }

        public static void CycleNextPlayer()
        {
            PlayerManager inst = PlayerManager.GetInstance();
            Debug.Assert(inst.poHead != null);
            Debug.Assert(inst.pCurPlayer != null);

            inst.pCurPlayer = inst.pCurPlayer.pNext == null ? (Player)inst.poHead : (Player)inst.pCurPlayer.pNext;
        }

        private static PlayerManager GetInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }



    }


}
