using BepInEx;
using RoR2;
using RoR2.ContentManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AccelPlus
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "Nuxlar";
        public const string PluginName = "AccelPlus";
        public const string PluginVersion = "1.0.1";

        internal static Main Instance { get; private set; }
        public static string PluginDirectory { get; private set; }

        public void Awake()
        {
            Instance = this;

            Log.Init(Logger);

            Accelify();
        }

        private static void Accelify()
        {
            AssetReferenceT<GameObject> toolbotRef = new AssetReferenceT<GameObject>(RoR2BepInExPack.GameAssetPathsBetter.RoR2_Base_Toolbot.ToolbotBody_prefab);
            AssetAsyncReferenceManager<GameObject>.LoadAsset(toolbotRef).Completed += (x) =>
            {
                Debug.LogWarning(x.Result);
                CharacterBody body = x.Result.GetComponent<CharacterBody>();
                body.baseAcceleration = 80f;
            };
            AssetReferenceT<GameObject> mageRef = new AssetReferenceT<GameObject>(RoR2BepInExPack.GameAssetPathsBetter.RoR2_Base_Mage.MageBody_prefab);
            AssetAsyncReferenceManager<GameObject>.LoadAsset(mageRef).Completed += (x) =>
            {
                CharacterBody body = x.Result.GetComponent<CharacterBody>();
                Debug.LogWarning(body);
                body.baseAcceleration = 80f;
            };
            AssetReferenceT<GameObject> fsRef = new AssetReferenceT<GameObject>(RoR2BepInExPack.GameAssetPathsBetter.RoR2_DLC2_FalseSon.FalseSonBody_prefab);
            AssetAsyncReferenceManager<GameObject>.LoadAsset(fsRef).Completed += (x) =>
            {
                CharacterBody body = x.Result.GetComponent<CharacterBody>();
                body.baseAcceleration = 80f;
            };
        }
    }
}
