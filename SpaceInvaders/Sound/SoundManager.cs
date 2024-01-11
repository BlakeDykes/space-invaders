using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SoundManager : ManagerBase
    {
        private static SoundManager instance = null;
        private IrrKlang.ISoundEngine SoundEngine;
        private Sound pCompSound;

        public SoundManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved, float volume) 
            : base(active, reserved, deltaGrow, initialReserved)
        {
            SoundEngine = new IrrKlang.ISoundEngine();
            SoundEngine.SoundVolume = volume;
            pCompSound = new Sound();
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved, float volume)
        {
            Debug.Assert(instance == null);

            if(instance == null)
            {
                instance = new SoundManager(active, reserved, deltaGrow, initialReserved, volume);

                instance.Initialize();
            }
        }

        private void Initialize()
        {
            SoundManager inst = SoundManager.GetInstance();

            inst.Add(Sound.Name.Shoot, "invaderkilled.wav");
            inst.Add(Sound.Name.AlienKilled, "shoot.wav");
            inst.Add(Sound.Name.Explosion, "explosion.wav");
            Sound pMarch1 = inst.Add(Sound.Name.AlienStep1, "fastinvader1.wav");
            Sound pMarch2 = inst.Add(Sound.Name.AlienStep2, "fastinvader2.wav", pMarch1);
            Sound pMarch3 = inst.Add(Sound.Name.AlienStep3, "fastinvader3.wav", pMarch2);
            Sound pMarch4 = inst.Add(Sound.Name.AlienStep4, "fastinvader4.wav", pMarch3);

            pMarch1.SetNextSound(pMarch4);
            inst.Add(Sound.Name.UFOLow, "ufo_lowpitch.wav");
            inst.Add(Sound.Name.UFOHigh, "ufo_highpitch.wav");
        }

        private Sound Add(Sound.Name name, string filePath)
        {
            SoundManager inst = SoundManager.GetInstance();

            Sound pSound = (Sound)inst.BaseAdd();

            IrrKlang.ISoundSource pSoundSource = inst.SoundEngine.AddSoundSourceFromFile(filePath);

            pSound.Set(name, pSoundSource);

            return pSound;
        }

        private Sound Add(Sound.Name name, string filePath, Sound nextSound)
        {
            SoundManager inst = SoundManager.GetInstance();

            Sound pSound = (Sound)inst.BaseAdd();

            IrrKlang.ISoundSource pSoundSource = inst.SoundEngine.AddSoundSourceFromFile(filePath);
            pSound.Set(name, pSoundSource, nextSound);
            return pSound;
        }

        public static Sound Find(Sound.Name name)
        {
            SoundManager inst = SoundManager.GetInstance();

            inst.pCompSound.SoundName = name;

            return (Sound)inst.BaseFind(inst.pCompSound);
        }

        public static void PlaySound(Sound.Name name, bool playLooped = false, bool startPaused = false, bool enableSoundEffects = false)
        {
            SoundManager inst = SoundManager.GetInstance();

            inst.pCompSound.SoundName = name;

            Sound pSound = (Sound)inst.BaseFind(inst.pCompSound);

            inst.SoundEngine.Play2D(pSound.GetSource(), playLooped, startPaused, enableSoundEffects);
        }

        public static void Update()
        {
            SoundManager inst = SoundManager.GetInstance();

            inst.SoundEngine.Update();
        }

        private static SoundManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        protected override NodeBase DerivedCreateNode()
        {
            return new Sound();
        }
    }
}
