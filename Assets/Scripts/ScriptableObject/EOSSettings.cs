using UnityEngine;
namespace eoschat
{
    /// <summary>
    /// EOS の設定情報
    /// </summary>
    [CreateAssetMenu(fileName = "EOSSettings", menuName = "ScriptableObjects/EOSSettings", order = 1)]
    public class EOSSettings : ScriptableObject
    {
        public string ProductName;
        public string ProductVersion;
        public string ClientId;
        public string ClientSecret;
        public string ProductId;
        public string SandboxId;
        public string DeploymentId;
    }
}