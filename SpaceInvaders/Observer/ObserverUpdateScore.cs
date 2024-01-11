using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverUpdateScore : Observer
    {
        private int ScoreIncrease;
        private GameObject pObject;

        public ObserverUpdateScore()
        {
            ScoreIncrease = 0;
        }

        public override void Notify()
        {
            ColPair pColPair = ColPairManager.GetActivePair();
            Debug.Assert(pColPair != null);

            this.pObject = (GameObject)pColPair.GetAlienObject();
            Debug.Assert(this.pObject != null);
            
            switch (this.pObject.GOName)
            {
                case GameObject.Name.Octo:
                    ScoreIncrease = 10;
                    break;
                case GameObject.Name.Crab:
                    ScoreIncrease = 20;
                    break;
                case GameObject.Name.Squid:
                    ScoreIncrease = 30;
                    break;
                case GameObject.Name.UFO:
                    ScoreIncrease = 300;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            ScoreManager.UpdateScore(Score.Name.Player1, ScoreIncrease);
        }
    }
}
