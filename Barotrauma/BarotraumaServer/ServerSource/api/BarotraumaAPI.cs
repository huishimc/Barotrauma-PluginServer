using System;
using System.Collections.Generic;
using System.Linq;
using Barotrauma.Networking;

namespace Barotrauma.ServerSource
{
    public class BarotraumaAPI : IBarotraumaAPI
    {
        //信息 or 命令
        private GameServer Server => GameMain.Server;

        public void SendMessageToPlayer(string playerName, string message)
        {
            if (Server == null) return;
            var client = Server.ConnectedClients.FirstOrDefault(c => c.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
            if (client != null)
            {
                Console.WriteLine($"[BarotraumaAPI] 准备向 {playerName} 发送消息: {message}");
                Server.SendDirectChatMessage(message, client, ChatMessageType.Server);
            }
        }

        public void BroadcastMessage(string message)
        {
            Server?.SendChatMessage(message, ChatMessageType.Server);
        }

        public void KickPlayer(string playerName, string reason = "")
        {
            if (Server == null) return;
            var client = Server.ConnectedClients.FirstOrDefault(c => c.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
            if (client != null)
            {
                if (string.IsNullOrEmpty(reason))
                    Server.KickClient(client, "被管理员踢出");
                else
                    Server.KickClient(client, reason);
            }
        }

        public string[] GetOnlinePlayers()
        {
            if (Server == null) return Array.Empty<string>();
            return Server.ConnectedClients.Select(c => c.Name).ToArray();
        }

        public string[] GetAllPlayers()
        {
            var server = GameServer.ServerInstance;
            if (server == null) return new string[0];

            return server.ConnectedClients.Select(c => c.Name).ToArray();
        }

        public void ExecuteCommand(string command)
        {
            DebugConsole.ExecuteCommand(command);
        }


        //标签

        private Dictionary<string, List<string>> playerTags = new Dictionary<string, List<string>>();

        public void AddTag(string playerName, string tag)
        {
            if (string.IsNullOrEmpty(playerName) || string.IsNullOrEmpty(tag)) return;

            if (!playerTags.ContainsKey(playerName))
            {
                playerTags[playerName] = new List<string>();
            }

            if (!playerTags[playerName].Contains(tag))
            {
                playerTags[playerName].Add(tag);
                Console.WriteLine($"[API] 给 {playerName} 添加了标签: {tag}");
            }
        }

        public string[] GetPlayerTags(string playerName)
        {
            if (playerTags.ContainsKey(playerName))
            {
                return playerTags[playerName].ToArray();
            }
            return new string[0];
        }

        public bool HasTag(string playerName, string tag)
        {
            return playerTags.ContainsKey(playerName) && playerTags[playerName].Contains(tag);
        }

        public void RemoveTag(string playerName, string tag)
        {
            if (playerTags.ContainsKey(playerName))
            {
                playerTags[playerName].Remove(tag);
                Console.WriteLine($"[API] 移除了 {playerName} 的标签: {tag}");

                // 如果该玩家没有标签了，删除条目
                if (playerTags[playerName].Count == 0)
                {
                    playerTags.Remove(playerName);
                }
            }
        }





    }
}