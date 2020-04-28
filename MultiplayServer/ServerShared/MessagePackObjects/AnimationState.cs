using MessagePack;
using UnityEngine;

namespace Assets.Scripts.ServerShared.MessagePackObjects
{
    [MessagePackObject]
    public class AnimationState
    {
        [Key(0)]
        public string Name { get; set; }
        [Key(1)]
        public float Value{ get; set; }
        [Key(2)]
        public float Speed { get; set; }
        [Key(3)]
        public bool IsPlaying { get; set; }
        public void CopyTo(AnimationState target)
        {
            target.Name = Name;
            target.Value = Value;
            target.Speed = Speed;
            target.IsPlaying = IsPlaying;
        }
        public bool Equal(AnimationState target)
        {
            return target.Name == Name
                && target.Value == Value
                && target.Speed == Speed
                && target.IsPlaying == IsPlaying;
        }
    }
}