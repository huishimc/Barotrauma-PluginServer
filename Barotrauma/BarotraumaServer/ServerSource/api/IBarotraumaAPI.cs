using System;

namespace Barotrauma.ServerSource
{
    public interface IBarotraumaAPI
    {

        /// 向指定玩家发送私聊消息

        void SendMessageToPlayer(string playerName, string message);

        /// 向所有玩家广播消息

        void BroadcastMessage(string message);

  
        /// 踢出玩家
 
        void KickPlayer(string playerName, string reason = "");

   
        /// 获取当前在线玩家列表

        string[] GetOnlinePlayers();

        string[] GetAllPlayers();


        /// 执行控制台命令

        void ExecuteCommand(string command);

        // 给玩家添加标签
        void AddTag(string playerName, string tag);

        // 获取玩家的所有标签
        string[] GetPlayerTags(string playerName);

        // 检查玩家是否有指定标签
        bool HasTag(string playerName, string tag);

        void RemoveTag(string playerName, string tag);








    }
}