using System;
using UnityEngine;
using UnityEngine.UI;

namespace Journey
{
    public class UISettingButtonWithSlider : MonoBehaviour, IScriptableObjectProperty
    {
        [SerializeField] private Setting setting;
        [SerializeField] private Text titleText;
        [SerializeField] private Text valueText;
        [SerializeField] private Slider slider;

        private AudioMixerFloatSettingSetting audioSetting;
        private float step;
        private int numberOfSteps;

        private void Start()
        {
            ApplyProperty(setting);
            UpdateInfo();
        }

        public void ApplyProperty(ScriptableObject property)
        {
            if (property == null) return;

            if (property is Setting == false)
                return;
            setting = property as Setting;
            audioSetting = property as AudioMixerFloatSettingSetting;

            if (audioSetting)
            {
                slider.maxValue = audioSetting.MaxVirtualValue;
                slider.minValue = audioSetting.MinVirtualValue;
                step = audioSetting.VirtualStep;
            }
        }

        public void UpdateSetting()
        {
            UpdateStep();
            SetSetting();
            UpdateInfo();
        }

        private void UpdateStep()
        {
            numberOfSteps = (int) (slider.maxValue / step);

            float range = (slider.value / slider.maxValue) * numberOfSteps;
            int ceil = Mathf.CeilToInt(range);
            slider.value = ceil * step;
        }

        private void SetSetting()
        {
            audioSetting?.SetValue(slider.value);
            setting?.Apply();
        }


        private void UpdateInfo()
        {
            titleText.text = setting.Title;
            valueText.text = setting.GetStringValue();
            slider.value = Int32.Parse(setting.GetStringValue());
        }
    }
}
