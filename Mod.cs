using HarmonyLib;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(InsideDebugModes.Mod), "InsideDebugModes", "1.0.0", "Penta", null)]
[assembly: MelonGame("Playdead", "INSIDE")]

namespace InsideDebugModes {
    static class CurrentCheatMode {
        public static CheatMode currentCheatMode = CheatMode.PlayThrough;
    }

    [HarmonyPatch("CheatManager", "IsActive")]
    class PatchIsActive
    {
        public static bool Prefix(ref bool __result, ref CheatMode __0)
        {
            if (__0 == CurrentCheatMode.currentCheatMode) {
                __result = true;
            } else {
                __result = false;
            }

            // skips the original
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "get_cheatsEnabled")]
    class PatchGetCheatsEnabled
    {
        public static bool Prefix(ref bool __result)
        {
            __result = true;
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "get_Main")]
    class PatchGetMain
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "get_Camera")]
    class PatchGetCamera
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "get_Audio")]
    class PatchGetAudio
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "get_Playthrough")]
    class PatchGetPlaythrough
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "get_Savepoints")]
    class PatchGetSavepoints
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "get_Rendering")]
    class PatchGetRendering
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "get_System")]
    class PatchGetSystem
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }
    
    [HarmonyPatch("CheatManager", "get_Timeline")]
    class PatchGetTimeline
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "get_Log")]
    class PatchGetLog
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "get_Recorder")]
    class PatchGetRecorder
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "get_Custom")]
    class PatchGetCustom
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "get_Signals")]
    class PatchGetSignals
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }

    [HarmonyPatch("CheatManager", "GetController")]
    class PatchGetController
    {
        public static bool Prefix(ref GameController __result)
        {
            __result = GameManager.controller;
            return false;
        }
    }

    public class Mod: MelonMod
    {
        public static MelonLogger.Instance Logger { get; private set; }

        public override void OnInitializeMelon()
        {
            Logger = LoggerInstance;

            HarmonyInstance.PatchAll();

            Logger.Msg("Initialized.");
        }

        public override void OnUpdate()
        {
            GUI.active = true;
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                CurrentCheatMode.currentCheatMode = CheatMode.PlayThrough;
            } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                CurrentCheatMode.currentCheatMode = CheatMode.Savepoints;
            } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                CurrentCheatMode.currentCheatMode = CheatMode.Camera;
            } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
                CurrentCheatMode.currentCheatMode = CheatMode.System;
            } else if (Input.GetKeyDown(KeyCode.Alpha5)) {
                CurrentCheatMode.currentCheatMode = CheatMode.Audio;
            } else if (Input.GetKeyDown(KeyCode.Alpha6)) {
                CurrentCheatMode.currentCheatMode = CheatMode.Timeline;
            } else if (Input.GetKeyDown(KeyCode.Alpha7)) {
                CurrentCheatMode.currentCheatMode = CheatMode.Log;
            } else if (Input.GetKeyDown(KeyCode.Alpha8)) {
                CurrentCheatMode.currentCheatMode = CheatMode.Rendering;
            } else if (Input.GetKeyDown(KeyCode.Alpha9)) {
                CurrentCheatMode.currentCheatMode = CheatMode.Custom;
            } else if (Input.GetKeyDown(KeyCode.Alpha0)) {
                CurrentCheatMode.currentCheatMode = CheatMode.FreeCamera;
            } else if (Input.GetKeyDown(KeyCode.I)) {
                CurrentCheatMode.currentCheatMode = CheatMode.Playback;
            } else if (Input.GetKeyDown(KeyCode.O)) {
                CurrentCheatMode.currentCheatMode = CheatMode.User;
            } else if (Input.GetKeyDown(KeyCode.P)) {
                CurrentCheatMode.currentCheatMode = CheatMode.Signals;
            }
        }

        public override void OnGUI()
        {
            GUI.Label(new Rect(0, 0, 500, 100), "Debug Mode is running! Current Mode: " + CurrentCheatMode.currentCheatMode.ToString() + ".");
        }
    }
}

