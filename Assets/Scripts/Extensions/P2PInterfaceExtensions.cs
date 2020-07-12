using UnityEngine;
using Epic.OnlineServices;
using Epic.OnlineServices.P2P;

namespace eoschat
{
    /// <summary>
    /// P2PInterface 拡張
    /// </summary>
    public static class P2PInterfaceExtensions
    {
        /// <summary>
        /// 短縮 SendPacket
        /// </summary>
        /// <param name="p2p">P2PInterface</param>
        /// <param name="socketName">ソケット名</param>
        /// <param name="remoteUserId">送信先ユーザーID</param>
        /// <param name="localUserId">ログインユーザーID</param>
        /// <param name="channel">チャンネル</param>
        /// <param name="data">データ</param>
        public static void SendPacket(this P2PInterface p2p, string socketName, ProductUserId remoteUserId, ProductUserId localUserId, byte channel, byte[] data)
        {
            var op = new SendPacketOptions
            {
                SocketId = new SocketId
                {
                    SocketName = socketName
                },
                RemoteUserId = remoteUserId,
                LocalUserId = localUserId,
                Channel = channel,
                Data = data
            };
            var result = p2p.SendPacket(op);
            if (result != Result.Success)
            {
                Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            }
        }

        /// <summary>
        /// 短縮 AddNotifyPeerConnectionRequest
        /// </summary>
        /// <param name="p2p">P2PInterface</param>
        /// <param name="socketName">ソケット名</param>
        /// <param name="localUserId">ログインユーザーID</param>
        public static void AddNotifyPeerConnectionRequest(this P2PInterface p2p, string socketName, ProductUserId localUserId, OnIncomingConnectionRequestCallback fun)
        {
            var op = new AddNotifyPeerConnectionRequestOptions
            {
                SocketId = new SocketId
                {
                    SocketName = socketName
                },
                LocalUserId = localUserId,
            };

            p2p.AddNotifyPeerConnectionRequest(op, null, fun);
        }

        /// <summary>
        /// 短縮 AcceptConnection
        /// </summary>
        /// <param name="p2p">P2PInterface</param>
        /// <param name="localUserId">ログインユーザーID</param>
        /// <param name="remoteUserId">送信元ユーザーID</param>
        /// <param name="socketName">ソケット名</param>
        public static void AcceptConnection(this P2PInterface p2p, ProductUserId localUserId, ProductUserId remoteUserId, string socketName)
        {
            var accOp = new AcceptConnectionOptions
            {
                LocalUserId = localUserId,
                RemoteUserId = remoteUserId,
                SocketId = new SocketId
                {
                    SocketName = socketName
                },
            };

            var result = p2p.AcceptConnection(accOp);
            if (result != Result.Success)
            {
                Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            }
        }

        /// <summary>
        /// 短縮 GetNextReceivedPacketSize
        /// </summary>
        /// <param name="p2p">P2PInterface</param>
        /// <param name="localUserId">ログインユーザーID</param>
        /// <param name="requestedChannel">チャンネルID</param>
        public static uint GetNextReceivedPacketSize(this P2PInterface p2p, ProductUserId localUserId, byte requestedChannel)
        {
            var sizeOp = new GetNextReceivedPacketSizeOptions
            {
                LocalUserId = localUserId,
                RequestedChannel = requestedChannel
            };
            uint size;
            var result = p2p.GetNextReceivedPacketSize(sizeOp, out size);
            if (result != Result.Success)
            {
                // メッセージが無くてもエラーになるので非表示
                //Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
            }
            return size;
        }

        /// <summary>
        /// 短縮 ReceivePacket
        /// </summary>
        /// <param name="p2p">P2PInterface</param>
        /// <param name="localUserId">ログインユーザーID</param>
        /// <param name="maxDataSizeBytes">受信バイトサイズ</param>
        /// <param name="requestedChannel">チャンネルID</param>
        public static (ProductUserId, SocketId, byte, byte[], uint) ReceivePacket(this P2PInterface p2p, ProductUserId localUserId, uint maxDataSizeBytes, byte requestedChannel)
        {
            var op = new ReceivePacketOptions
            {
                LocalUserId = localUserId,
                MaxDataSizeBytes = maxDataSizeBytes,
                RequestedChannel = requestedChannel
            };

            // ※ 配列作っておかないとエラーになる
            byte[] rawData = new byte[maxDataSizeBytes];
            var result = p2p.ReceivePacket(op, out ProductUserId remoteUserId, out SocketId socketId, out byte channel, ref rawData, out uint outBytesWritten);
            if (result != Result.Success)
            {
                Debug.LogError($"error {DebugTools.GetClassMethodName()}:{result}");
                return default;
            }
            return (remoteUserId, socketId, channel, rawData, outBytesWritten);
        }
    }
}
