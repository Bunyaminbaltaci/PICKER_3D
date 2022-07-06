using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CD_Player", menuName = "Data/Player", order = 0)]
    public class CD_Player : ScriptableObject
    {
        public PlayerData Data;
    }
}