using Rocket.API;

namespace papershredder432.PSHighJump
{
    public class PSHighJumpConfiguration : IRocketPluginConfiguration
    {
        public float LowJumpMultiplier;
        public float MedJumpMultiplier;
        public float HighJumpMultiplier;

        public void LoadDefaults()
        {
            LowJumpMultiplier = 2;
            MedJumpMultiplier = 3;
            HighJumpMultiplier = 4;
        }
    }
}