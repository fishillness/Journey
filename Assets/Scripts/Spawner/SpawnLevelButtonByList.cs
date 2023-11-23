using UnityEngine;

namespace Journey
{
    public class SpawnLevelButtonByList : SpawnObjectByPropertiesList
    {
        [SerializeField] private LevelList levelList;

        protected override void ApplyProperties()
        {
            for (int i = 0; i < levelList.LevelsList.Levels.Length; i++)
            {
                GameObject gameObject = Instantiate(prefab, parent);
                IScriptableObjectProperty scriptableObjectProperty = gameObject.GetComponent<IScriptableObjectProperty>(); 
                scriptableObjectProperty.ApplyProperty(levelList.LevelsList.Levels[i]);
            }
        }
    }
}
