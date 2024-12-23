# Background Customizer
A background customization mod for Getting Over It with Bennett Foddy

## Installation
Firstly you need to install [BepInEx](https://github.com/BepInEx/BepInEx/releases), follow [these instructions](https://docs.bepinex.dev/articles/user_guide/installation/index.html) to install BepInEx for Getting Over It.

Once that is complete, head to the [releases](https://github.com/The-head-obamid/GOI-Background-Customizer/releases) and download the latest version of the plugin, and place this in the  `Getting Over It/BepInEx/plugins` folder, once you've done that, that's the installation done.

This plugin does build with some features for ingame customization, so if you'd like to utilize that, you can download [ConfigurationManager](https://github.com/BepInEx/BepInEx.ConfigurationManager) and click the releases and install it the same way you did this plugin, you can read the readme there for more information on how to make use of this

## Configuration
Running the game with the plugin installed will generate the necessary config files and folders for you to make use of the mod in `BepInEx/config`.

You can edit the `GOI.plugins.BackgroundMod.cfg` file in that folder as per your preference, different sky zones are categorized into separate areas in the config file which you can configure there, as well as lighting values and fog.

## Building from source & development
To make contributions to the plugin, after cloning the repository, create a `lib` folder in the `Background Customizer` folder.  In this folder you put all the referenced libraries which can be found in the game data folder.
Once done, you can run `dotnet build` with the -c parameter specifying either B5 or B6 for BepInEx 5 or 6 respectively to generate a build.

Dependencies:
* Assembly-CSharp.dll
