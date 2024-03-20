using HarmonyLib;
using UnityEngine;
namespace BetterTail.Patches
{
    [HarmonyPatch(typeof(VRRig), "Start")]
    internal class VRRigPatch
    {
        static void Postfix()
        {
            GameObject Tail = GorillaTagger.Instance.offlineVRRig.transform.Find("rig/body/2024_03_Nowruz Body/LBAFW./TigerTail").gameObject;
            Tail.GetComponent<SkinnedMeshRenderer>().material = Main.furMat;
            Tail.GetComponent<SkinnedMeshRenderer>().material.color = GorillaTagger.Instance.offlineVRRig.mainSkin.material.color;
        }
    }
}
