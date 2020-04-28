using MessagePack;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ServerShared.MessagePackObjects
{
    [MessagePackObject]
    public class Avatar
    {
        [Key(0)]
        public string Name { get; set; }
        [Key(1)]
        public Vector3 Position { get; set; }
        [Key(2)]
        public Quaternion Rotation { get; set; }
        [Key(3)]
        public List<AnimationState> Animations { get; set; }
    }
}