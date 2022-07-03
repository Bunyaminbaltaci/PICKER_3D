using Managers;
using UnityEngine;

namespace Controllers
{
    public class LevelClearLoaderController : MonoBehaviour
    {
        public void InitialzedLevel(int _levelId, Transform levelHolder)
        {
            Instantiate(Resources.Load<GameObject>($"Prefabs/LevelPrefabs/level {_levelId}"), levelHolder);
        }

        public void ClearActiveLevel(Transform levelHolder)
        {
            Destroy(levelHolder.GetChild(0).gameObject);
        }
    }
}