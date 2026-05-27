using System;
using System.Collections.Generic;
using System.Linq;
using Barotrauma.Networking;

namespace Barotrauma.ServerSource
{
    public delegate void CommandHandler(string playerName, string[] args);

    public static class CommandManager
    {
        private static Dictionary<string, CommandHandler> handlers = new Dictionary<string, CommandHandler>();

        public static void Register(string commandName, CommandHandler callback)
        {
            string lowerCmd = commandName.ToLower();
            if (handlers.ContainsKey(lowerCmd))
            {
                Console.WriteLine($"[CommandManager] 指令 {commandName} 已存在");
                return;
            }
            handlers[lowerCmd] = callback;
            Console.WriteLine($"[CommandManager] 已注册指令: {commandName}");
        }

        internal static bool TryExecute(Client sender, string text)
        {
            Console.WriteLine($"[CommandManager] 收到文本: {text} 来自 {sender.Name}");
            if (string.IsNullOrEmpty(text) || !text.StartsWith("/"))
                return false;

            string[] parts = text.Substring(1).Split(' ');
            string cmd = parts[0].ToLower();
            string[] args = parts.Length > 1 ? parts.Skip(1).ToArray() : new string[0];

            if (handlers.TryGetValue(cmd, out var callback))
            {
                Console.WriteLine($"[CommandManager] 执行指令 {cmd}，参数 {string.Join(",", args)}");
                callback(sender.Name, args);
                Console.WriteLine($"[CommandManager] 指令执行完成");
                return true;
            }
            else
            {
                // 直接回复，不经过 API
                GameMain.Server.SendDirectChatMessage($"未知指令: {cmd}", sender, ChatMessageType.Server);
                return true;
            }
        }













    }
}