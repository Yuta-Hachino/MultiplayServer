using Assets.Scripts.ServerShared.MessagePackObjects;
using Cysharp.Threading;
using MagicOnion.Server.Hubs;
using MessagePack;
using Sample.Shared.Hubs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class MultiplayHub : StreamingHubBase<IMultiplayHub, IMultiplayHubReceiver>, IMultiplayHub
{
    Player _me = new Player();
    static Room _room = new Room();
    IGroup _group;

    LogicLooper _looper = null;

    public async Task<Room> JoinAsync(Player player, string roomName)
    {
        _group = await this.Group.AddAsync(roomName);//ルームに参加&ルームを保持
        player.CopyTo(_me);
        _room.Players.Add(_me);//自分の情報も保持
        Logger.Debug("PlayerCount: " + _room.Players.Count);
        //参加したことをルームに参加している全メンバーに通知
        this.Broadcast(_group).OnJoin(_me);
        if (_looper == null)
        {
            _looper = new LogicLooper(30);
            _looper.RegisterActionAsync((in LogicLooperActionContext ctx) =>
            {
                if (_room != null)
                {
                    this.Broadcast(_group).OnUpdateRoom(_room);
                }
                return true;
            });
        }

        return _room;
    }

    public async Task LeaveAsync()
    {
        
        //ルーム内のメンバーから自分を削除
        await _group.RemoveAsync(this.Context);
        _room.Players.Remove(_me);
        //退室したことを全メンバーに通知
        this.Broadcast(_group).OnLeave(_me);
    }

    public async Task SendMessageAsync(string message)
    {
        //発言した内容を全メンバーに通知
        this.Broadcast(_group).OnSendMessage(_me.Name, message);
    }

    public async Task UpdatePlayerAsync(Player position)
    {
        // サーバー上の情報を更新
        var target = _room.Players.FirstOrDefault(player => player.Name == position.Name);
        if (target != null) position.CopyTo(target);
    }

    protected override ValueTask OnDisconnected()
    {
        _room.Players.Remove(_me);
        //退室したことを全メンバーに通知
        this.Broadcast(_group).OnLeave(_me);
        return CompletedTask;
    }
}