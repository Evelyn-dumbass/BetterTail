using BepInEx;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
namespace BetterTail
{
    [BepInPlugin("Evelyn.BetterTail", "BetterTail", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        public static Material furMat;
        void Awake() { GorillaTagger.OnPlayerSpawned(OnGameInit); new Harmony("Eve.BetterTail").PatchAll(Assembly.GetExecutingAssembly()); }

        void OnGameInit() => furMat = Instantiate(LoadAssetBundle("BetterTail.Resource.fur").LoadAsset<Material>("furMat"));

        public AssetBundle LoadAssetBundle(string path)
        {
            Assembly.GetExecutingAssembly().GetManifestResourceStream(path).Close();
            return AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(path));
        }
    }
}
