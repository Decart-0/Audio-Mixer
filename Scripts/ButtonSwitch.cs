using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonSwitch : ButtonBase
{
    private const string TextDisabledButton = "выкл звук";
    private const string TextEnabledButton = "вкл звук";

    private const float VolumeMuted = 0f; 
    private const float VolumeUnmuted = 1f;

    [SerializeField] private AudioMixerGroup _mixerUI;
    [SerializeField] private TMP_Text _buttonText;

    private bool _isMuted;

    private void Start()
    {
        _isMuted = true;
        UpdateButtonText();
        SetAudioListenerVolume();
    }

    protected override void ClickButton() 
    {
        base.ClickButton();
        ToggleSound();
        UpdateButtonText();
    }

    private void ToggleSound()
    {
        _isMuted = !_isMuted;
        SetAudioListenerVolume();
    }

    private void SetAudioListenerVolume()
    {
        AudioListener.volume = !_isMuted ? VolumeMuted : VolumeUnmuted;
    }

    private void UpdateButtonText()
    {
        _buttonText.text = !_isMuted ? TextDisabledButton : TextEnabledButton;
    }
}