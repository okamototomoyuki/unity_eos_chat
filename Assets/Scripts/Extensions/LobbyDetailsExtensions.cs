using Cysharp.Threading.Tasks;
using UnityEngine;
using Epic.OnlineServices;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Lobby;

namespace eoschat
{
    /// <summary>
    /// LobbySearch 拡張
    /// </summary>
    public static class LobbyDetailsExtensions
    {
        /// <summary>
        /// 短縮 GetLobbyOwner
        /// </summary>
        /// <returns>ユーザーID</returns>
        public static ProductUserId GetLobbyOwner(this LobbyDetails detail) => detail.GetLobbyOwner(new LobbyDetailsGetLobbyOwnerOptions());
    }
}
