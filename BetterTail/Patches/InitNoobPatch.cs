using GorillaExtensions;
using HarmonyLib;
using UnityEngine;

namespace BetterTail
{
    [HarmonyPatch(typeof(VRRig), "InitializeNoobMaterialLocal")]
    internal class InitNoobPatch
    {
        public static void Postfix(ref VRRig __instance)
        {
            Transform Tail = __instance.transform.Find("rig/body/2024_03_Nowruz Body/LBAFW./TigerTail");
            Tail.GetComponent<SkinnedMeshRenderer>().material = Main.furMat;
            Tail.GetComponent<SkinnedMeshRenderer>().material.color = __instance.playerColor;
        }
    }
}
