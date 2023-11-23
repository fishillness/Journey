using UnityEngine;

namespace Journey
{
    public class LevelList : MonoBehaviour
    {
        [SerializeField] private LevelListInfo levelsList;

        public LevelListInfo LevelsList => levelsList;
    }
}

