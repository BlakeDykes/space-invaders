using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Score : SLink
    {
        Font pFontScore;
        public int ScoreNumber;
        public Name ScoreName;

        public enum Name
        {
            HiScore,
            Player1,
            Player2,
        }

        public Score()
        {
            this.pFontScore = null;
            ScoreNumber = 0;
        }

        public Score(Score.Name scoreName)
        {
            this.ScoreName = scoreName;
        }

        public void SetFont(Font fontScore)
        {
            this.pFontScore = fontScore;
            Debug.Assert(this.pFontScore != null);
        }

        public int UpdateScore(int increase)
        {
            this.ScoreNumber += increase;
            this.pFontScore.UpdateMessage(ScoreNumber.ToString("D4"));

            return this.ScoreNumber;
        }

        public void RefreshScoreMessage()
        {
            this.pFontScore.UpdateMessage(ScoreNumber.ToString("D4"));
        }

        public void ResetScore()
        {
            this.ScoreNumber = 0;
            this.pFontScore.UpdateMessage(ScoreNumber.ToString("D4"));
        }

        public override bool Compare(NodeBase pNode)
        {
            Debug.Assert(pNode != null);
            Score pComp = (Score)pNode;

            return this.ScoreName == pComp.ScoreName;
        }

        public int GetScore()
        {
            return this.ScoreNumber;
        }
    }
}
