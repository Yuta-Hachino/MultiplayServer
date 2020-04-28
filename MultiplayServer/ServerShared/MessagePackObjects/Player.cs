using MessagePack;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ServerShared.MessagePackObjects
{
    [MessagePackObject]
    public class Player
    {
        [Key(0)]
        public string Name { get; set; }
        [Key(1)]
        public string ModelName { get; set; }
        [Key(2)]
        public Vector3 HeadPosition { get; set; }
        [Key(3)]
        public Quaternion HeadRotation { get; set; }
        [Key(4)]
        public Vector3 RightPosition { get; set; }
        [Key(5)]
        public Quaternion RightRotation { get; set; }
        [Key(6)]
        public Vector3 LeftPosition { get; set; }
        [Key(7)]
        public Quaternion LeftRotation { get; set; }
        [Key(8)]
        public List<AnimationState> Animations { get; set; } = new List<AnimationState>();
        [Key(9)]
        public bool IsManager{ get; set; }
        [Key(10)]
        public bool IsEventer { get; set; }

        public void CopyTo(Player target)
        {
            target.Name = this.Name;
            target.ModelName = this.ModelName;
            target.HeadPosition = this.HeadPosition;
            target.HeadRotation = this.HeadRotation;
            target.RightPosition = this.RightPosition;
            target.RightRotation = this.RightRotation;
            target.LeftPosition = this.LeftPosition;
            target.LeftRotation = this.LeftRotation;
            target.Animations.Clear();
            target.Animations.AddRange(this.Animations);
            target.IsManager = this.IsManager;
            target.IsEventer = this.IsEventer;
        }
    }
}