using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ScoreManager : ManagerBase
    {
        private static ScoreManager instance = null;
        private Score pCompScore;
        private int HiScore;

        private ScoreManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved) 
            : base(active, reserved, deltaGrow, initialReserved)
        {
            pCompScore = new Score();
            this.HiScore = 0;
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            Debug.Assert(instance == null);

            if(instance == null)
            {
                instance = new ScoreManager(active, reserved, deltaGrow, initialReserved);
            }
        }

        public static void Add(Score.Name name)
        {
            ScoreManager inst = ScoreManager.GetInstance();

            Score pScore = (Score)inst.BaseAdd();

            pScore.ScoreName = name;
        }

        public static void SetFont(Score.Name name, Font.Name fontName)
        {
            Score pScore = Find(name);
            Font pFont = FontManager.Find(fontName);

            pScore.SetFont(pFont);
        }

        public static Score Find(Score.Name name)
        {
            ScoreManager inst = ScoreManager.GetInstance();

            inst.pCompScore.ScoreName = name;

            Score pScore = (Score)inst.BaseFind(inst.pCompScore);

            Debug.Assert(pScore != null);

            return pScore;
        }

        public static void UpdateScore(Score.Name name, int scoreIncrease)
        {
            ScoreManager inst = ScoreManager.GetInstance();

            Score pScore = Find(name);

            pScore.UpdateScore(scoreIncrease);

            if(pScore.ScoreNumber > inst.HiScore)
            {
                inst.SetHiScore(scoreIncrease);
            }
        }

        public static void RefreshScore(Score.Name name)
        {
            Score pScore = Find(name);

            pScore.RefreshScoreMessage();
        }

        public static void ResetScore(Score.Name name)
        {
            Score pScore = ScoreManager.Find(name);

            pScore.ResetScore();
        }

        private void SetHiScore(int scoreIncrease)
        {
            this.HiScore += scoreIncrease;

            Score hiScore = ScoreManager.Find(Score.Name.HiScore);
            hiScore.UpdateScore(scoreIncrease);
        }

        public static int GetScore(Score.Name name)
        {
            ScoreManager inst = ScoreManager.GetInstance();

            Score pScore = ScoreManager.Find(name);

            return pScore.GetScore();
        }

        public static int GetHiScore()
        {
            ScoreManager inst = ScoreManager.GetInstance();

            return inst.HiScore;
        }

        protected override NodeBase DerivedCreateNode()
        {
            return new Score();
        }

        private static ScoreManager GetInstance()
        {
            Debug.Assert(instance != null);
            
            return instance;
        }
    }
}
