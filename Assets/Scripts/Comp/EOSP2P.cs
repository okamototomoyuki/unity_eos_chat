using Cysharp.Threading.Tasks;
using Epic.OnlineServices;
using Epic.OnlineServices.Lobby;
using Epic.OnlineServices.P2P;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace eoschat
{
    /// <summary>
    /// EOS の P2P でチャット
    /// </summary>
    public class EOSP2P : MonoBehaviour
    {
        public TMP_InputField inptDevPort = null;
        public TMP_InputField inptDevName = null;
        public Button btnLogin = null;

        public CanvasGroup lobbyRoot = null;
        public Button btnCreateLobby = null;
        public TMP_InputField inptLobbyId = null;
        public Button btnSearchLobby = null;

        public CanvasGroup p2pRoot = null;
        public TMP_InputField inptSocketId = null;
        public TMP_InputField inptChannelId = null;

        public CanvasGroup chatRoot = null;
        public TMP_InputField inptSendMsg = null;
        public Button btnSend = null;
        public TMP_InputField inptRecMsg = null;

        ProductUserId m_localUserId = null;
        ProductUserId m_targetUserId = null;
        string m_joinLobbyId = null;

        /// <summary>
        /// 開始
        /// </summary>
        void Start()
        {
            btnLogin.SetOnClick(() => _Login().Forget());
            btnCreateLobby.SetOnClick(() => _CreateLobby().Forget());
            btnSearchLobby.SetOnClick(() => _JoinLobby().Forget());
            btnSend.SetOnClick(_Send);
        }

        /// <summary>
        /// 更新
        /// </summary>
        void Update()
        {
            var p2p = EOSComponent.p2p;

            lobbyRoot.alpha = m_localUserId != null ? 1 : 0;
            p2pRoot.alpha = m_joinLobbyId != null ? 1 : 0;
            chatRoot.alpha = m_joinLobbyId != null ? 1 : 0;

            var size = p2p.GetNextReceivedPacketSize(m_localUserId, inptChannelId.text.ToByte());
            if (size > 0)
            {
                var (_, _, _, rawData, _) = p2p.ReceivePacket(m_localUserId, size, inptChannelId.text.ToByte());
                var rec = Encoding.UTF8.GetString(rawData);
                inptRecMsg.text = $"{rec}\n{inptRecMsg.text}";
            }
        }

        /// <summary>
        /// ログイン
        /// </summary>
        /// <returns>タスク</returns>
        async UniTask _Login()
        {
            var auth = EOSComponent.auth;
            var con = EOSComponent.connect;
            var authRes = await auth.Login(Epic.OnlineServices.Auth.LoginCredentialType.Developer, $"localhost:{inptDevPort.text}", inptDevName.text);
            if (authRes == null)
            {
                return;
            }

            var token = auth.CopyUserAuthToken(authRes.LocalUserId);
            if (token == null)
            {
                return;
            }

            var conRes = await con.Login(token.AccessToken, Epic.OnlineServices.Connect.ExternalCredentialType.Epic);
            if (conRes == null)
            {
                return;
            }

            m_localUserId = conRes.LocalUserId;
        }

        /// <summary>
        /// ロビー作成
        /// </summary>
        /// <returns>タスク</returns>
        async UniTask _CreateLobby()
        {
            var lobby = EOSComponent.lobby;

            var result = await lobby.CreateLobby(m_localUserId, 4, LobbyPermissionLevel.Publicadvertised);
            if (result == null)
            {
                return;
            }

            var handle = lobby.UpdateLobbyModification(m_localUserId, result.LobbyId);

            // TODO 検索は機能していないが検索条件付与
            handle.AddAttribute("name", true, LobbyAttributeVisibility.Public);

            m_joinLobbyId = result.LobbyId;
            inptLobbyId.text = m_joinLobbyId;

            _RecReq();
        }

        /// <summary>
        /// ロビーに入室
        /// </summary>
        /// <returns>タスク</returns>
        async UniTask _JoinLobby()
        {
            var lobby = EOSComponent.lobby;

            var search = lobby.CreateLobbySearch(10);
            if (search == null)
            {
                return;
            }

            // TODO 検索が死んでるので ID 直書き
            //search.SetParameter("name", true, ComparisonOp.Equal);
            search.SetLobbyId(inptLobbyId.text);

            var result = await search.Find(m_localUserId);
            if (result == null)
            {
                return;
            }

            var count = search.GetSearchResultCount();
            Debug.Log($"{nameof(count)}:{count}");

            var detail = search.CopySearchResultByIndex(0);

            m_targetUserId = detail.GetLobbyOwner();
            Debug.Log($"{nameof(m_targetUserId)}:{m_targetUserId}");

            var info = await lobby.JoinLobby(detail, m_localUserId);
            m_joinLobbyId = info.LobbyId;

            // P2P リクエストのための初回送信
            _Send();
        }

        /// <summary>
        /// P2P 送信
        /// </summary>
        void _Send()
        {
            var p2p = EOSComponent.p2p;
            var bytes = Encoding.UTF8.GetBytes(inptSendMsg.text);
            p2p.SendPacket(inptSocketId.text, m_targetUserId, m_localUserId, inptChannelId.text.ToByte(), bytes);
        }

        /// <summary>
        /// P2P リクエストの受信
        /// </summary>
        void _RecReq()
        {
            var p2p = EOSComponent.p2p;
            p2p.AddNotifyPeerConnectionRequest(inptSocketId.text, m_localUserId, e =>
            {
                Debug.Log($"ClientData:{e.ClientData} LocalUserId:{e.LocalUserId} RemoteUserId:{e.RemoteUserId} SocketName:{e.SocketId.SocketName}");

                p2p.AcceptConnection(e.LocalUserId, e.RemoteUserId, e.SocketId.SocketName);
                m_targetUserId = e.RemoteUserId;
            });
        }
    }
}
