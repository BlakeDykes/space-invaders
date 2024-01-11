using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SceneState
    {

        protected StateName mStateName;

        public enum StateName
        {
            Select,
            Play,
            GameOver
        }

        public abstract void Initialize(float systemTime);
        public abstract void Update(float systemTime);
        public abstract void Draw();
        public abstract void Transition(float systemTime);

        public virtual StateName GetStateName()
        {
            return this.mStateName;
        }
    }
}
