using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barotrauma.ServerSource
{
     public interface IPlugin
    {
            string Name { get; }
            string Version { get; }

            // 程序启动时加载 .dll 时调用（只调用一次）
            void OnLoad();

            // 服务端启动完成，进入大厅时调用
            void OnServerStart();

            // 回合开始（游戏开始）时调用
            void OnRoundStart();

            // 回合结束时调用
            void OnRoundEnd();

            // 服务端关闭时调用
            void OnServerStop();
        
    }
}
