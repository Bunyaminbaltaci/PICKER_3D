using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CD_LevelList", menuName = "LevelList/New_LevelList", order = 0)]
    public class CD_LevelList : ScriptableObject
    {
        public List<Level> Levels = new List<Level>();
    }
}