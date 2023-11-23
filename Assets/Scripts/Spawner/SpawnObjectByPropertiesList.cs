using UnityEngine;

namespace Journey
{
    public class SpawnObjectByPropertiesList : MonoBehaviour
    {
        [SerializeField] protected Transform parent;
        [SerializeField] protected GameObject prefab;
        [SerializeField] private ScriptableObject[] properties;

        [ContextMenu(nameof(SpawnInEditMode))]
        public void SpawnInEditMode()
        {
            if (Application.isPlaying == true) return;

            GameObject[] allObject = new GameObject[parent.childCount];

            for (int i = 0; i < parent.childCount; i++)
            {
                allObject[i] = parent.GetChild(i).gameObject;
            }

            for (int i = 0; i < allObject.Length; i++)
            {
                DestroyImmediate(allObject[i]);
            }

            ApplyProperties();
        }

        protected virtual void ApplyProperties()
        {
            for (int i = 0; i < properties.Length; i++)
            {
                GameObject gameObject = Instantiate(prefab, parent);
                IScriptableObjectProperty scriptableObjectProperty = gameObject.GetComponent<IScriptableObjectProperty>();
                scriptableObjectProperty.ApplyProperty(properties[i]);
            }
        }
    }
}
