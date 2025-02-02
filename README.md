# NativeLib
DockItemLib is a [SalemModLoader](https://github.com/Curtbot9000/SalemModLoader) library for [Town of Salem 2](https://store.steampowered.com/app/2140510/Town_of_Salem_2/) by DigitalBanditos.

DockItemLib is developed by VoidBehemoth and is unaffiliated with with DigitalBanditos.

## Development
Are you a modder that wants to use this library? Creating a new DockItem is easy! Just use DockItemLib.API and create a CustomDockItem. The following are its parameters:
| Parameter        | Type              | Definition                                                |
|------------------|-------------------|-----------------------------------------------------------|
| Name             | string            | Required. The internal name of the string.                |
| Label            | string            | Required. The default visible label                       |
| Localization Key | string            | Optional. A localization key for the visible label.       |
| Sprite           | Sprite            | Required. The icon for the DockItem.                      |
| Hotkey Type      | HotKey.HotKeyType | Required. The HotKey that will trigger the DockItem.      |
| Listener         | Action            | Required. Called when the DockItem is clicked.            |
| Condition        | Func<bool>        | Optional. Returns true if the DockItem should be visible. |

Happy modding!

## Building
Want to build the latest (potentially unreleased) version of the mod yourself? Follow these steps:

1. Make sure you have the latest version of the repo on your client.
2. Create a file in the same directory as AutoGG.csproj called SteamLibrary.targets and copy the following into it:
```
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
    <PropertyGroup>
        <SteamLibraryPath>REPLACE</SteamLibraryPath>
    </PropertyGroup>
</Project>
```
3. Replace the text 'REPLACE' with the location of your 'SteamLibrary' folder (or 'ApplicationSupport/Steam' on OSX).
4. Build the mod using either the [dotnet cli](https://dotnet.microsoft.com/en-us/download), [Visual Studio](https://visualstudio.microsoft.com/), or some other means.

NOTE: This repository is licensed under the GNU General Public License v3.0. Learn more about what this means [here](https://www.tldrlegal.com/license/gnu-general-public-license-v3-gpl-3).