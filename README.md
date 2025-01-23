# Inside Debug Modes

This in-progress Melonloader Mod activates some of the developer tools left in the game.
Currently, only the Savepoints module is properly usable. To switch between the available
modes, use the number keys (0-9) and "i", "o", and "p" on the keyboard. In the top right,
is says which mode is currently active.

## Compilation instructions

Note: Only tested on Linux! It should work on Windows too though.

1. Use [MegaDumper](https://github.com/CodeCracker-Tools/MegaDumper) to extract all the loaded .NET assemblies. This is needed, since the Assembly-CSharp.dll and the Assembly-CSharp-firstpass.dll are "embedded" in the executable.
2. Put the dll files into the libs folder.
3. Then download MelonLoader 0.6.6 from [here](https://github.com/LavaGang/MelonLoader/releases).
4. Copy the dll files from the MelonLoader/net35 folder into the libs folder.

Run `dotnet build` to produce the compiled dll file in the bin folder.

## Running

1. Download MelonLoader 0.6.6 from [here](https://github.com/LavaGang/MelonLoader/releases).
2. Install MelonLoader by putting the contents of the MelonLoader.x64.zip file into your game directory.
3. Run the game once. If on Linux, set the environment variable `WINEDLLOVERRIDES` to the value `version=n,b`.
4. Put the compiled dll file into the Mods directory.
5. Run the game again. You should see a message in the top left if the mod is running.
