using Cysharp.Threading.Tasks;
using UnityEngine;
using Epic.OnlineServices;
using Epic.OnlineServices.Connect;

namespace eoschat
{
    /// <summary>
    /// ConnectInterface 拡張
    /// </summary>
    public static class ConnectInterfaceExtensions
    {
        /// <summary>
        /// 非同期 Login
        /// </summary>
        /// <param name="type">ログイン種別</param>
        /// <param name="id">ID</param>
        /// <param name="token">トークン</param>
        /// <returns>タスク</returns>
        public static async UniTask<LoginCallbackInfo> Login(this ConnectInterface conn, string token, ExternalCredentialType type)
        {
            var op = new LoginOptions
            {
                Credentials = new Credentials
                {
                    Token = token,
                    Type = type,
                },
            };
            LoginCallbackInfo info = null;
            conn.Login(op, null, e =>
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
