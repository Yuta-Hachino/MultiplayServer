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
    public class ObjectTransform
    {
        [Key(0)]
        public string Name { get; set; }
        [Key(1)]
        public Vector3 Position { get; set; }
        [Key(2)]
        public Quaternion Rotation { get; set; }
        [Key(3)]
        public AnimationState Animation { get; set; } = new AnimationState();
        public void CopyTo(ObjectTransform target)
        {
            target.Name = Name;
            target.Position = new Vector3(Position.x, Position.y, Position.z);
            target.Rotation = new Quaternion(Rotation.x, Rotation.y, Rotation.z, Rotation.w);
            Animation.CopyTo(target.Animation);
        }
        public bool Equal(ObjectTransform target)
            => target.Name == Name
                && target.Position.Equals(Position)
                && target.Rotation.Equals(Rotation)
                && target.Animation.Equal(Animation);
    }
}
