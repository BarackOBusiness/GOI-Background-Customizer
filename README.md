# Background Customizer
A background customization mod for Getting Over It with Bennett Foddy, the clouds variant.

The clouds significantly lower performance, aren't made to be configurable and also are made to work in a somewhat hacky way, I don't recommend using this branch, compile it yourself if you're that persistent. But if you manage to solve some of these problems and weird behaviors that the clouds exhibit, feel free to contribute.

## Installation
Compile it, then move it into the plugins folder.

## Configuration
Running the game with the plugin installed will generate the necessary config files and folders for you to make use of the mod in `BepInEx/config`.

You can edit the `GOI.plugins.BackgroundMod.cfg` file in that folder as per your preference, different sky zones are categorized into separate areas in the config file which you can configure there, as well as lighting values and fog. Yeah yeah you know this already

## Building from source & development
To make contributions to the plugin, after cloning the repository, create a `lib` folder in the `Background Customizer` folder.  In this folder you put all the referenced libraries which can be found in the game data folder, if a specified UnityEngine module is missing on compile time, put it into a `net45` folder inside of the libs folder.

Dependencies:
* Assembly-CSharp
* netstandard