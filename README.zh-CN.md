# Barotrauma Plugin Server

中文 | [English](./README.md)

**让潜渊症服务端支持动态加载 .dll 插件，客户端原版即可进入**

这是一个基于 Barotrauma 官方源码修改的**服务端插件系统**。你可以在不修改客户端的情况下，为你的服务器添加各种自定义功能。

---

## 正在实现功能

| 预期功能 | 实现 |
|------|------|
| 动态加载 .dll 插件 | ✅ |
| 生命周期 | ✅ |
| 聊天栏指令注册 | ✅ |
| 控制台命令注册 | ❌ |
| 玩家系统 | ✅ |
| API 接口 | ✅ |
| 客户端是否需要安装 Mod | 不需要 |

我不知道要实现什么了，建议投稿给我🤓

---

## 快速开始

### 服务端安装

1. 下载 Releases 中的 `DedicatedServer.dll`
2. 备份你原来的 `DedicatedServer.dll`
3. 替换服务端目录下的同名文件
4. 在服务端 exe 同级目录创建 `Plugins` 文件夹（首次启动会自动创建）
5. 将插件 `.dll` 放入 `Plugins` 文件夹
6. 启动服务端

### 开发插件

[developer documentation](https://github.com/huishimc/Barotrauma-PluginServer/wiki/%E5%BC%80%E5%8F%91%E8%80%85%E6%96%87%E6%A1%A3)

# Barotrauma

Copyright © FakeFish Ltd 2017-2026

Before downloading the source code, please read the [EULA](EULA.txt).

If you have a question or an issue to report, please check our [Contribution Guideline](https://github.com/Regalis11/Barotrauma/blob/master/CONTRIBUTING.md).

If you're interested in working on the code, either to develop mods or to contribute something to the repository, you will also find instructions in the [Contribution Guideline](https://github.com/Regalis11/Barotrauma/blob/master/CONTRIBUTING.md).

## Links:

**Official Website:** www.barotraumagame.com

**Steam Forums:** https://steamcommunity.com/app/602960/discussions/

**Discord:** https://discordapp.com/invite/undertow

**Wiki:** https://barotraumagame.com/wiki/Main_Page

## Prerequisities:
### Windows
- [Visual Studio](https://www.visualstudio.com/vs/community/) with C# 10 support (VS 2022 or later recommended)
### Linux
- [.NET 8 SDK](https://docs.microsoft.com/en-us/dotnet/core/install/linux)
### macOS
- [Visual Studio 2022 for Mac](https://visualstudio.microsoft.com/vs/mac/)
