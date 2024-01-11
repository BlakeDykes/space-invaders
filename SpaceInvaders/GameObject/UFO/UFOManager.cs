using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFOManager
    {
        private static UFOManager instance = null;
        private UFOGroup pUFOGroup;
        private UFO pUFO;
        private Random rnd = new Random();
        private CommandLoopSoundUFO pLoopSoundCommand;
        private UFOFactory uFactory;

        private UFOManager()
        {
            this.pUFOGroup = new UFOGroup();
            GameObjectNodeManager.Attach(pUFOGroup, true);

            this.pLoopSoundCommand = new CommandLoopSoundUFO();

            this.uFactory = new UFOFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.CollisionBoxes);
        }

        public static void Create()
        {
            if (instance == null)
            {
                instance = new UFOManager();
            }
            else
            {
                UFOManager inst = UFOManager.GetInstance();

                inst.Reset();
            }
        }

        public static void ActivateUFO()
        {
            UFOManager inst = UFOManager.GetInstance();

            int screenSide = inst.rnd.Next(0, 2);

            inst.pUFO = (UFO)inst.uFactory.CreateUFO(Constants.UFO_START_X + (Constants.UFO_X_OFFSET * screenSide), Constants.UFO_Y, screenSide, Constants.RED, true);

            TimerManager.Add(TimerEvent.Name.LoopSoundUFO, Constants.UFO_SOUND_LOOP_TIME, inst.pLoopSoundCommand, true);
        }

        public static UFOGroup GetGroup()
        {
            UFOManager inst = UFOManager.GetInstance();

            return inst.pUFOGroup;
        }

        public static UFO GetUFO()
        {
            UFOManager inst = UFOManager.GetInstance();

            return inst.pUFO;
        }

        private void Reset()
        {
            this.pUFOGroup = new UFOGroup();
            GameObjectNodeManager.Attach(pUFOGroup, true);

            this.uFactory = new UFOFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.CollisionBoxes);
        }

        private static UFOManager GetInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }
    }
}
