# Barotrauma Plugin Server

[中文](./README.zh-CN.md) | English

**Enable Barotrauma server to dynamically load .dll plugins, original client can join without any modifications**

This is a **server plugin system** modified from Barotrauma's official source code. You can add custom features to your server without modifying the client.

---

## Features in Progress

| Feature | Implemented |
|------|------|
| Dynamic .dll plugin loading | ✅ |
| Lifecycle events | ✅ |
| Chat command registration | ✅ |
| Console command registration | ❌ |
| Player system | ✅ |
| API interface | ✅ |
| Client needs to install Mod | No |

I don't know what else to implement, suggestions are welcome🤓

---

## Quick Start

### Server Installation

1. Download `DedicatedServer.dll` from Releases
2. Backup your original `DedicatedServer.dll`
3. Replace the file in your server directory
4. Create a `Plugins` folder in the same directory as your server exe (will be created automatically on first startup)
5. Place your plugin `.dll` files into the `Plugins` folder
6. Start the server

### Plugin Development

I'm writing a simple tutorial

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
