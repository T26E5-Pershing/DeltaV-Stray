using Content.Server.Administration;
using Content.Server.Chat.Managers;
using Content.Shared.Administration;
using Robust.Shared.Console;

namespace Content.Server.Chat.Commands
{
    [AdminCommand(AdminFlags.Mapping)]
    internal sealed class MappersChatCommand : IConsoleCommand
    {
        public string Command => "masay";
        public string Description => "Send chat messages to the private mapper chat channel.";
        public string Help => "masay <text>";

        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            var player = shell.Player;

            if (player == null)
            {
                shell.WriteError("You can't run this command locally.");
                return;
            }

            if (args.Length < 1)
                return;

            var message = string.Join(" ", args).Trim();
            if (string.IsNullOrEmpty(message))
                return;

            IoCManager.Resolve<IChatManager>().TrySendOOCMessage(player, message, OOCChatType.Mapper);
        }
    }
}
