using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ServerShared.MessagePackObjects
{
    [MessagePackObject]
    public class Room
    {
        [Key(0)]
        public string Name { get; set; }
        [Key(1)]
        public string ModelName { get; set; }
        [Key(2)]
        public string Password { get; set; }
        [Key(3)]
        public List<Player> Players { get; set; } = new List<Player>();
        [Key(4)]
        public List<ObjectTransform> Objects { get; set; } = new List<ObjectTransform>();
        public void CopyTo(Room target)
        {
            target.Name = Name;
            target.ModelName = ModelName;
            target.Password = Password;
            target.Players.Clear();
            target.Players.AddRange(Players);
            target.Objects.Clear();
            target.Objects.AddRange(Objects);
        }
        public bool Equal(Room target)
            => target.Name == Name
            && target.ModelName == ModelName
            && target.Password == Password
            && target.Players.SequenceEqual(Players)
            && target.Objects.SequenceEqual(Objects);
    }
}
