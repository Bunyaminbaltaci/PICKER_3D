using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelList", menuName = "LevelList/New_LevelList", order = 0)]
    public class LevelList : ScriptableObject
    {
        public List<Level> Levels = new List<Level>();
    }
}