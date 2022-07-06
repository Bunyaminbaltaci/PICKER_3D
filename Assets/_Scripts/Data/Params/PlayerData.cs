using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlayerData
    {
        public PlayerMovementData MovementData;
        public PlayerThrowForceData throwForceData;
    }

    [Serializable]
    public class PlayerMovementData
    {
        public float ForwardSpeed;
        public float SidewaysSpeed;
        public float ForwardForceCounter;
    }
    [Serializable]
    public class PlayerThrowForceData
    {
        public Vector2 ThrowForce = new Vector2(2, 2);
    }
}