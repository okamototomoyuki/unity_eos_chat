using Cysharp.Threading.Tasks;
using UnityEngine;
using Epic.OnlineServices;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Lobby;

namespace eoschat
{
    /// <summary>
    /// LobbyModification 拡張
    /// </summary>
    public static class LobbyModificationExtensions
    {
        /// <summary>
        /// 短縮 UpdateLobbyModification
        /// </summary>
        /// <param name="lobby">LobbyModification</param>
        /// <param name="key">キー</param>
        /// <param name="value">値</param>
        /// <param name="visibility">属性の公開設定</param>
        public static void AddAttribute(this LobbyModification modify, string key, AttributeDataValue value, LobbyAttributeVisibility visibility)
        {
            var attr = new AttributeData();
            attr.Key = key;
            attr.Value = value;
            var addOp = new LobbyModificationAddAttributeOptions
            {
                Attribute = attr,
                Visibility = visibility
            };
            var addRes = modify.AddAttribute(addOp);
            if (addRes != Result.Success)
            {
                Debug.LogError($"{nameof(addRes)}:{addRes}");
            }
        }
    }
}
