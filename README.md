# This fork assumes the basis of Bright's mods.

# Installation
### 1. Download and install [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.413-windows-x64-installer)
### 2. Install the framework mod
   - Download [BepInEx](https://github.com/LocalizeLimbusCompany/BepInEx_For_LLC/releases/tag/v6.0.1-LLC);
   - Drag the contents of the archive to the game folder
### 3. Let the framework load the files for the plugins to work and wait for the main screen to load and only then close the game
### 4. Prepare the game folder
   - On this step everything should work..
   - ![This is how should look your game folder](/src/firstscreen.png?raw=true)
### 5. Install my mod
   - Download [dll](../../releases), then drag it to ../Limbus Company/BIE/plugins/..
   - ![This is how should look your plugin folder with installed dll](/src/secondscreen.png?raw=true)
   - (i dont know how to draw with mouse)
   - LAUNCH, MANAGER ESQUIRE!!!!!
   - (after first launch, it downloads my json file from this repo to properly work. if you hesitate about safety - download any dll ripper or reader and observe each line of my code.. or just look at my folder /src for mods)

# THESE MODS ARE ONLY CLIENT-SIDE (means that all modifications from this dll will be visible only to you)
## How to work with NicknamesNoBanners:
- If you didnt read manual above, then wait for downloading this userid.json
- Open userid.json (in the same folder as .dll file form installation) by any txt editor
- Add as many brackets, as you want
- Key "true_id" - there should be any limbus id
- Key "custom_name" - freely write here what you want (no, because there are limitations from above)
  Examples: "HeathcliffsWife" - allowed, "F@ck." - not allowed
- Key "enablebanners" - Disables banners on your profile and friends list, set "true" or "false".
- Key "checkyourfriends" - strange thing, but it will check your friend list and output some info about them in BIE console: True ID, last online and LVL. (This list sorted by LVLs)
- Save your changes
  (changes apply after restart)

### Rules for NicknamesNoBanners:
- Max 13 characters
- Special symbols or space are not allowed
- You can't enter in global search "custom_name" to find someone, it will still accepts only limbus id
- forgor about the rest..

## How to work with CustomLoadingScreen:
- Wait for download of congif.json
- Open userid.json (in the same folder as .dll file form installation) by any txt editor
- DO NOT ENTER OR ADD ANY BRACKETS.
- Key "loadingScreenMode" - accepts 3 modes:
  "random" - default option, uses arts in your folder (with extension .jpg or .png in the same folder as .dll file form installation) and CG from PMs assets.
  "onlyCG" - speaks for itself, uses only PMs assets.
  "onlyArts" - uses only arts from mod folder.
- Key "loadingScreenSpeed" - sets the speed of PMs CG videos. Write any number you want, I didnt test it with negative or extremely high numbers.
- Key "loadingScreenZoom" - sets the zoom of PMs CG videos. Applies from above.
  (If you want to know, my fav settings for these keys: 1.5 on speed and 1.25 on zoom)

## How to work with ShowDialogs:
- Dont have any rules, just place it in your plugins folder.

## Contacts?
- Discord: disaer
  (I dont know how badly I messed up about performance.. feel free to write)
  For donuts: I dont know how to accept any, DM me on discord if you really want to help in any way lol
