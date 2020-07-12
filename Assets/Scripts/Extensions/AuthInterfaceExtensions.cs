using UnityEngine.Events;
using Epic.OnlineServices.Auth;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Epic.OnlineServices;

namespace eoschat
{
    /// <summary>
    /// AuthInterface 拡張
    /// </summary>
    public static class AuthInterfaceExtensions
    {
        /// <summary>
        /// 非同期 Login
        /// </summary>
        /// <param name="auth">AuthInterface</param>
        /// <param name="type">ログイン種別</param>
        /// <param name="id">ID</param>
        /// <param name="token">トークン</param>
        /// <returns>タスク</returns>
        public static async UniTask<LoginCallbackInfo> Login(this AuthInterface auth, LoginCredentialType type, string id, string token)
        {
            var op = new LoginOptions();
            op.Credentials = new Credentials
            {
                Type = type,
                Id = id,
                Token = token,
            };

            LoginCallbackInfo info = null;
            auth.Login(op, null, e =>
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
        /// 省略 CopyUserAuthToken
        /// </summary>
        /// <param name="auth">AuthInterface</param>
        /// <param name="localUserId">ログインユーザーID</param>
        /// <returns>トークン</returns>
        public static Token CopyUserAuthToken(this AuthInterface auth, EpicAccountId localUserId)
        {
            var result = auth.CopyUserAuthToken(new CopyUserAuthTokenOptions(), localUserId, out Token token);
            if (result == Result.Success)
            {
                return token;
            }
            Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            return null;
        }
    }
}
