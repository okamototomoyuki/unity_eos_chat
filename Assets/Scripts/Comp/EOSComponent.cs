using Epic.OnlineServices;
using Epic.OnlineServices.Auth;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Lobby;
using Epic.OnlineServices.P2P;
using Epic.OnlineServices.Platform;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace eoschat
{
    /// <summary>
    /// EOS メイン
    /// </summary>
    public class EOSComponent : MonoBehaviour
    {
        static EOSComponent _ins = null;

        [SerializeField]
        EOSSettings settings = null;

        PlatformInterface m_platformInterface = null;
        public static PlatformInterface platform => _ins.m_platformInterface;
        public static AuthInterface auth => platform.GetAuthInterface();
        public static P2PInterface p2p => platform.GetP2PInterface();
        public static LobbyInterface lobby => platform.GetLobbyInterface();
        public static ConnectInterface connect => platform.GetConnectInterface();

        /// <summary>
        /// 開始
        /// </summary>
        void Start()
        {
            _ins = this;

            var initializeOptions = new InitializeOptions();
            initializeOptions.ProductName = settings.ProductName;
            initializeOptions.ProductVersion = settings.ProductVersion;
            var result = PlatformInterface.Initialize(initializeOptions);

            // ※ Unity Editor は AlreadyConfigured を飛ばさないとアプリが動かない。
            if (result == Result.Success || result == Result.AlreadyConfigured)
            {
                var clientCredentials = new ClientCredentials();
                clientCredentials.ClientId = settings.ClientId;
                clientCredentials.ClientSecret = settings.ClientSecret;

                var options = new Options();
                options.ClientCredentials = clientCredentials;
                options.ProductId = settings.ProductId;
                options.SandboxId = settings.SandboxId;
                options.DeploymentId = settings.DeploymentId;

                m_platformInterface = PlatformInterface.Create(options);
                if (m_platformInterface == null)
                {
                    throw new Exception("Failed to create platform");
                }
            }
            else
            {
                throw new Exception("Failed to initialize platform:" + result);
            }

            Debug.Log($"Init:{result}");
        }

        /// <summary>
        /// 更新
        /// </summary>
        void Update()
        {
            m_platformInterface.Tick();
        }

        // ※ TODO Unity では破棄処理が正常に動かない
        //void OnApplicationQuit()
        //{
        //    m_platformInterface?.Release();
        //    m_platformInterface = null;
        //    PlatformInterface.Shutdown();
        //}
    }
}
