using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Player : SLink
    {
        public int Lives;
        public PlayerName Id;
        public SpriteProxy poHeadLife;

        private SpriteBatch LifeMarkerBatch;

        public enum PlayerName
        {
            Player_1,
            Player_2,

            Uninitialized
        }

        public Player(PlayerName id)
        {
            this.Id = id;
            this.poHeadLife = null;
            this.Lives = 0;

            switch (this.Id)
            {
                case PlayerName.Player_1:
                    this.LifeMarkerBatch = SpriteBatchManager.Find(SpriteBatch.Name.LifeMarkers_Player_1);
                    break;
                case PlayerName.Player_2:
                    this.LifeMarkerBatch = SpriteBatchManager.Find(SpriteBatch.Name.LifeMarkers_Player_2);
                    break;
                default:
                    this.LifeMarkerBatch = null;
                    break;
            }

        }

        public void GenerateLives(int lifeCount)
        {
            for (int i = 0; i < lifeCount; i++)
            {
                this.poHeadLife = SpriteProxyManager.Add(Sprite.Name.Ship);
                this.poHeadLife.UpdateLocal(Constants.SHIP_STARTING_X_POS + (this.Lives * 65.0f), Constants.SHIP_LIFE_Y_POS);
                this.poHeadLife.SwapColor(Constants.GREEN);

                this.LifeMarkerBatch.Attach(this.poHeadLife);

                this.Lives++;
            }
        }

        public void RemoveLife()
        {
            if(Lives != 0)
            {
                SpriteProxy pLife = this.poHeadLife;
                this.poHeadLife = (SpriteProxy)pLife.pNext;
                pLife.Remove();

            }
            Lives--;
        }

        public void Reset()
        {
            this.LifeMarkerBatch = SpriteBatchManager.Find(SpriteBatch.Name.LifeMarkers_Player_1);
            int newLives = Constants.STARTING_LIFE_COUNT - this.Lives;

            if(newLives > 0)
            {
                GenerateLives(newLives);
                this.Lives = Constants.STARTING_LIFE_COUNT;
            }

        }

        public override bool Compare(NodeBase pNode)
        {
            Player pComp = (Player)pNode;

            return this.Id == pComp.Id;
        }
    }
}
