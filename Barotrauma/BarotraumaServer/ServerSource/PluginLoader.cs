using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Barotrauma.ServerSource
{
    internal class PluginLoader
    {
        private List<IPlugin> plugins = new List<IPlugin>();

        // 1. 程序启动时调用（加载 .dll）
        public void LoadAllPlugins()
        {
            string pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            Console.WriteLine($"[插件加载器] 插件目录: {pluginPath}");
            Console.WriteLine($"[插件加载器] 目录存在: {Directory.Exists(pluginPath)}");

            if (!Directory.Exists(pluginPath))
            {
                Directory.CreateDirectory(pluginPath);
                Console.WriteLine("[插件加载器] 已创建 Plugins 文件夹");
                return;
            }

            string[] allFiles = Directory.GetFiles(pluginPath);
            Console.WriteLine($"[插件加载器] 文件夹里共 {allFiles.Length} 个文件");
            foreach (string f in allFiles)
            {
                Console.WriteLine($"[插件加载器]   找到文件: {Path.GetFileName(f)}");
            }

            // 再找 .dll
            string[] dllFiles = Directory.GetFiles(pluginPath, "*.dll");
            Console.WriteLine($"[插件加载器] 找到 {dllFiles.Length} 个 .dll 文件");

            foreach (string dllPath in dllFiles)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(dllPath);

                    var pluginTypes = assembly.GetTypes()
                        .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);

                    foreach (var type in pluginTypes)
                    {
                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                        plugin.OnLoad();  // 调用插件的 OnLoad
                        plugins.Add(plugin);
                        Console.WriteLine($"[插件加载器] 已加载: {plugin.Name} v{plugin.Version}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[插件加载器] 加载失败 {Path.GetFileName(dllPath)}: {ex.Message}");
                }
            }

            Console.WriteLine($"[插件加载器] 共加载 {plugins.Count} 个插件");
        }

        // 2. 服务端启动进入大厅时调用
        public void OnServerStart()
        {
            foreach (var plugin in plugins)
            {
                try
                {
                    plugin.OnServerStart();
                    Console.WriteLine($"[插件加载器] 服务端启动: {plugin.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[插件加载器] {plugin.Name} OnServerStart 失败: {ex.Message}");
                }
            }
        }

        // 3. 回合开始（游戏开始）时调用
        public void OnRoundStart()
        {
            foreach (var plugin in plugins)
            {
                try
                {
                    plugin.OnRoundStart();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[插件加载器] {plugin.Name} OnRoundStart 失败: {ex.Message}");
                }
            }
        }

        // 4. 回合结束时调用
        public void OnRoundEnd()
        {
            foreach (var plugin in plugins)
            {
                try
                {
                    plugin.OnRoundEnd();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[插件加载器] {plugin.Name} OnRoundEnd 失败: {ex.Message}");
                }
            }
        }

        // 5. 服务端关闭时调用
        public void OnServerStop()
        {
            foreach (var plugin in plugins)
            {
                try
                {
                    plugin.OnServerStop();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[插件加载器] {plugin.Name} OnServerStop 失败: {ex.Message}");
                }
            }
        }
    }
}
