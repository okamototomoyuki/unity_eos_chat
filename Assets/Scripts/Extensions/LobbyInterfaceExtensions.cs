using Cysharp.Threading.Tasks;
using UnityEngine;
using Epic.OnlineServices;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Lobby;

namespace eoschat
{
    /// <summary>
    /// LobbyInterface 拡張
    /// </summary>
    public static class LobbyInterfaceExtensions
    {
        /// <summary>
        /// 非同期 CreateLobby
        /// </summary>
        /// <param name="lobby">LobbyInterface</param>
        /// <param name="localUserId">ログインユーザーのID</param>
        /// <param name="maxLobbyMembers">最大人数</param>
        /// <param name="permissionLevel">公開設定</param>
        /// <returns>タスク</returns>
        public static async UniTask<CreateLobbyCallbackInfo> CreateLobby(this LobbyInterface lobby, ProductUserId localUserId, uint maxLobbyMembers, LobbyPermissionLevel permissionLevel)
        {
            var lobbyOp = new CreateLobbyOptions
            {
                LocalUserId = localUserId,
                MaxLobbyMembers = maxLobbyMembers,
                PermissionLevel = permissionLevel,
            };
            CreateLobbyCallbackInfo info = null;
            lobby.CreateLobby(lobbyOp, null, e =>
            {
                info = e;
            });
            while (info == null)
            {
                await UniTask.NextFrame();
            }

            if (info.ResultCode == Result.Success)
            {
                return info;
            }
            Debug.LogError($"error {DebugTools.GetClassMethodName()}:{info.ResultCode}");
            return null;
        }

        /// <summary>
        /// 短縮 UpdateLobbyModification
        /// </summary>
        /// <param name="lobby">LobbyInterface</param>
        /// <param name="localUserId">ログインユーザーID</param>
        /// <param name="LobbyId">ロビーID</param>
        /// <returns>ハンドル</returns>
        public static LobbyModification UpdateLobbyModification(this LobbyInterface lobby, ProductUserId localUserId, string lobbyId)
        {
            var modOp = new UpdateLobbyModificationOptions
            {
                LocalUserId = localUserId,
                LobbyId = lobbyId
            };

            LobbyModification handle;
            var result = lobby.UpdateLobbyModification(modOp, out handle);
            if (result == Result.Success)
            {
                return handle;
            }
            Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            return null;
        }

        /// <summary>
        /// 短縮 UpdateLobbyModification
        /// </summary>
        /// <param name="lobby">LobbyInterface</param>
        /// <param name="maxResults">最大検索数</param>
        /// <returns>ロビー検索</returns>
        public static LobbySearch CreateLobbySearch(this LobbyInterface lobby, uint maxResults)
        {
            var lobbyOp = new CreateLobbySearchOptions
            {
                MaxResults = maxResults
            };

            LobbySearch search;
            var result = lobby.CreateLobbySearch(lobbyOp, out search);
            if (result == Result.Success)
            {
                return search;
            }
            Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            return null;
        }

        /// <summary>
        /// 非同期 JoinLobby
        /// </summary>
        /// <param name="lobby">LobbyInterface</param>
        /// <param name="lobbyDetailsHandle">部屋詳細</param>
        /// <param name="localUserId">ログインユーザーID</param>
        /// <returns>タスク</returns>
        public static async UniTask<JoinLobbyCallbackInfo> JoinLobby(this LobbyInterface lobby, LobbyDetails lobbyDetailsHandle, ProductUserId localUserId)
        {
            var joinOp = new JoinLobbyOptions
            {
                LobbyDetailsHandle = lobbyDetailsHandle,
                LocalUserId = localUserId
            };
            JoinLobbyCallbackInfo info = null;
            lobby.JoinLobby(joinOp, null, e =>
            {
                info = e;
            });
            while (info == null)
            {
                await UniTask.NextFrame();
            }

            if (info.ResultCode == Result.Success)
            {
                return info;
            }
            Debug.LogError($"error {DebugTools.GetClassMethodName()}:{info.ResultCode}");
            return null;
        }
    }
}
