using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class InputData
    {
        public float HorizontalInputSpeed=2f;
        public Vector2 Clamp=new Vector2(-2,2);
        public float ClampSpeed=0.007f;
    }
}