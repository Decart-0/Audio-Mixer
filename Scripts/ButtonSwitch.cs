using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using Slider = UnityEngine.UI.Slider;

public class ButtonSwitch : ButtonBase
{
    private const string TextDisabledButton = "выкл звук";
    private const string TextEnabledButton = "вкл звук";
    private const string VolumePrefKey = "Volume";

    [SerializeField] private AudioMixerGroup _mixerUI;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private Slider _slider;

    private void Update()
    {
        UpdateButtonText();
    }

    protected override void ClickButton() 
    {
        base.ClickButton();
        ToggleSlider();
        UpdateButtonText();
    }

    private void ToggleSlider()
    {
        _slider.value = _slider.value == _slider.minValue ? PlayerPrefs.GetFloat(VolumePrefKey, _slider.maxValue) : _slider.minValue;
    }

    private void UpdateButtonText()
    {
        _buttonText.text = _slider.value != 0 ? TextDisabledButton : TextEnabledButton;
    }
}