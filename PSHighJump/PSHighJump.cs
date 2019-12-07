using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace papershredder432.PSHighJump
{
    public class PSHighJump : RocketPlugin<PSHighJumpConfiguration>
    {
        public static PSHighJump Instance;
        public List<UnturnedPlayer> uJumpers = new List<UnturnedPlayer>();

        protected override void Load()
        {
            Instance = this;
            UnturnedPlayerEvents.OnPlayerUpdateGesture += UnturnedPlayerEvents_OnPlayerUpdateGesture;
            Logger.LogWarning("[PSHighJump] Loaded, made by papershredder432, join the support Discord here: https://discord.gg/ydjYVJ2");
        }

        public void UnturnedPlayerEvents_OnPlayerUpdateGesture(UnturnedPlayer player, UnturnedPlayerEvents.PlayerGesture gesture)
        {
            if (gesture == UnturnedPlayerEvents.PlayerGesture.Salute)
            {
                if (!player.HasPermission("ps.lowjump")) return;
                uJumpers.Add(player);
                player.Player.movement.sendPluginJumpMultiplier(Instance.Configuration.Instance.LowJumpMultiplier);
                player.Player.movement.sendPluginGravityMultiplier(Instance.Configuration.Instance.LowJumpMultiplier);
            }

            if (gesture == UnturnedPlayerEvents.PlayerGesture.Facepalm)
            {
                if (!player.HasPermission("ps.medjump")) return;
                uJumpers.Add(player);
                player.Player.movement.sendPluginJumpMultiplier(Instance.Configuration.Instance.MedJumpMultiplier);
                player.Player.movement.sendPluginGravityMultiplier(Instance.Configuration.Instance.MedJumpMultiplier);
            }

            if (gesture == UnturnedPlayerEvents.PlayerGesture.Wave)
            {
                if (!player.HasPermission("ps.highjump")) return;
                uJumpers.Add(player);
                player.Player.movement.sendPluginJumpMultiplier(Instance.Configuration.Instance.HighJumpMultiplier);
                player.Player.movement.sendPluginGravityMultiplier(Instance.Configuration.Instance.HighJumpMultiplier);
            }
            
            if (gesture == UnturnedPlayerEvents.PlayerGesture.Point)
            {
                uJumpers.Add(player);
                player.Player.movement.sendPluginJumpMultiplier(1);
                player.Player.movement.sendPluginGravityMultiplier(1);
            }
        }

        protected override void Unload()
        {
            Instance = null;
            UnturnedPlayerEvents.OnPlayerUpdateGesture += UnturnedPlayerEvents_OnPlayerUpdateGesture;
            Logger.LogWarning("[PSHighJump] Unloaded.");
        }
    }
}