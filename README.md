# Background Customizer
A background customization mod for Getting Over It with Bennett Foddy

## Installation
Firstly you need to install [BepInEx](https://github.com/BepInEx/BepInEx/releases), follow [these instructions](https://docs.bepinex.dev/articles/user_guide/installation/index.html) to install BepInEx for Getting Over It.

Once that is complete, head to the [releases](https://github.com/The-head-obamid/GOI-Background-Customizer/releases) and download the latest version of the plugin, and place this in the  `Getting Over It/BepInEx/plugins` folder, once you've done that, that's the installation done.

## Configuration
Running the game with the plugin installed will generate the necessary config files and folders for you to make use of the mod in `BepInEx/config`.

You can edit the `GOI.plugins.BackgroundMod.cfg` file in that folder as per your preference, different sky zones are categorized into separate areas in the config file which you can configure there, as well as lighting values and fog.

## Building from source & development
To make contributions to the plugin, after cloning the repository, create a `lib` folder in the `Background Customizer` folder.  In this folder you put all the referenced libraries which can be found in the game data folder, if a specified UnityEngine module is missing on compile time, put it into a `net45` folder inside of the libs folder.

Dependencies:
* Assembly-CSharp