using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Sound : SLink
    {
        public Sound.Name SoundName;
        IrrKlang.ISoundSource pIKSound;
        Sound NextSound;

        public enum Name 
        {
            Shoot,
            AlienKilled,
            Explosion,
            AlienStep1,
            AlienStep2,
            AlienStep3,
            AlienStep4,
            UFOLow,
            UFOHigh,
            Uninitialized
        }

        public Sound()
        {
            this.SoundName = Name.Uninitialized;
            this.pIKSound = null;
            this.NextSound = null;
        }

        public void Set(Sound.Name name, IrrKlang.ISoundSource sound)
        {
            this.SoundName = name;
            this.pIKSound = sound;
            this.NextSound = null;
        }

        public void Set(Sound.Name name, IrrKlang.ISoundSource sound, Sound nextSound)
        {
            this.SoundName = name;
            this.pIKSound = sound;
            this.NextSound = nextSound;
        }

        public void SetNextSound(Sound pSound)
        {
            this.NextSound = pSound;
        }

        public Sound GetNextSound()
        {
            return this.NextSound;
        }

        public IrrKlang.ISoundSource GetSource()
        {
            Debug.Assert(pIKSound != null);
            return this.pIKSound;
        }

        public override bool Compare(NodeBase pNode)
        {
            Sound pComp = (Sound)pNode;

            return this.SoundName == pComp.SoundName;
        }
    }
}
