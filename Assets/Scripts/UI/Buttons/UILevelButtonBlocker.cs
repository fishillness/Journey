using UnityEngine;

namespace Journey
{
    public class UILevelButtonBlocker : MonoBehaviour
    {
        private UILevelButton[] buttons;

        private void Start()
        {
            buttons = GetComponentsInChildren<UILevelButton>();
            BlockUILevelButtons();
        }


        public void BlockUILevelButtons()
        {
            if (buttons == null) return;

            for (int i = 1; i < buttons.Length; i++)
            {
                if (LevelUtil.FindSavedByLevel(buttons[i - 1].LevelInfo.LevelName) == 0)
                {
                    buttons[i].SetNonInteractable();
                }
            }
        }
    }
}
