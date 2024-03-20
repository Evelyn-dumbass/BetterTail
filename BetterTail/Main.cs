using BepInEx;
using HarmonyLib;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
namespace BetterTail
{
    [BepInPlugin("Evelyn.BetterTail", "BetterTail", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        public static Material furMat;
        void Awake() { GorillaTagger.OnPlayerSpawned(OnGameInit); new Harmony("Eve.BetterTail").PatchAll(Assembly.GetExecutingAssembly()); }

        async void OnGameInit()
        {
            furMat = Instantiate(LoadAssetBundle("BetterTail.Resource.fur").LoadAsset<Material>("furMat"));

            await Task.Delay(3000);

            GameObject Tail = GorillaTagger.Instance.offlineVRRig.transform.Find("rig/body/2024_03_Nowruz Body/LBAFW./TigerTail").gameObject;
            Tail.GetComponent<SkinnedMeshRenderer>().material = furMat;
            Tail.GetComponent<SkinnedMeshRenderer>().material.color = GorillaTagger.Instance.offlineVRRig.mainSkin.material.color;
        }

        public AssetBundle LoadAssetBundle(string path)
        {
            Assembly.GetExecutingAssembly().GetManifestResourceStream(path).Close();
            return AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(path));
        }
    }
}