using System;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Data
{
   
    [Serializable]
    public class Level 
    {
        public List<Stage> StagesList = new List<Stage>(3);

    }
}