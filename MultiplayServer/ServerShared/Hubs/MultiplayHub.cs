using Assets.Scripts.ServerShared.MessagePackObjects;
using MagicOnion;
using System.Threading.Tasks;
using UnityEngine;

namespace Sample.Shared.Hubs
{
    /// <summary>
    /// CLient -> ServerのAPI
    /// </summary>
    public interface IMultiplayHub : IStreamingHub<IMultiplayHub, IMultiplayHubReceiver>
    {
        /// <summary>
        /// ゲームに接続することをサーバに伝える
        /// </summary>
        Task<Room> JoinAsync(Player player, string roomName);
        /// <summary>
        /// ゲームから切断することをサーバに伝える
        /// </summary>
        Task LeaveAsync();
        /// <summary>
        /// メッセージをサーバに伝える
        /// </summary>
        Task SendMessageAsync(string message);
        /// <summary>
        /// 移動したことをサーバに伝える
        /// </summary>
        Task UpdatePlayerAsync(Player player);
    }

    /// <summary>
    /// Server -> ClientのAPI
    /// </summary>
    public interface IMultiplayHubReceiver
    {
        /// <summary>
        /// 誰かがゲームに接続したことをクライアントに伝える
        /// </summary>
        void OnJoin(Player player);
        /// <summary>
        /// 誰かがゲームから切断したことをクライアントに伝える
        /// </summary>
        void OnLeave(Player player);
        /// <summary>
        /// 誰かが発言した事をクライアントに伝える
        /// </summary>
        void OnSendMessage(string name, string message);
        /// <summary>
        /// 誰かが移動した事をクライアントに伝える
        /// </summary>
        void OnUpdatePlayer(Player player);
        void OnUpdateRoom(Room room);
    }
}