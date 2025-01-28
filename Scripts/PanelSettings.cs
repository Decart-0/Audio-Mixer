using UnityEngine;
using UnityEngine.Audio;

public class PanelSettings : MonoBehaviour
{
    private const string ParamMasterVolume = "MasterVolume";
    private const string ParamUIVolume = "UIVolume";
    private const string ParamButtonVolume = "ButtonVolume";
    private const string ParamMusicVolume = "MusicVolume";

    private const float MaxVolume = 0f;
    private const float MinVolume = -80f;

    [SerializeField] private AudioMixerGroup _mixerMaster;
    [SerializeField] private AudioMixerGroup _mixerUI;
    [SerializeField] private AudioMixerGroup _mixerMusic;
    [SerializeField] private AudioMixerGroup _mixerButton;

    [SerializeField] private bool _isSoundOn;

    private void Awake()
    {
        _isSoundOn = true;
        SetMasterVolume(_isSoundOn ? MaxVolume : MinVolume);
    }

    public void ToggleMusic()
    {
        _isSoundOn = !_isSoundOn;
        SetMasterVolume(_isSoundOn ? MaxVolume : MinVolume);
    }

    public void ChangeUIVolume(float volume) 
    {
        SetVolume(_mixerUI, ParamUIVolume, volume);
    }

    public void ChangeMusicVolume(float volume)
    {
        SetVolume(_mixerMusic, ParamMusicVolume, volume);
    }

    public void ChangeButtonVolume(float volume) 
    {
        SetVolume(_mixerButton, ParamButtonVolume, volume);
    }

    private void SetMasterVolume(float volume)
    {
        _mixerMaster.audioMixer.SetFloat(ParamMasterVolume, volume);
    }

    private void SetVolume(AudioMixerGroup mixerGroup, string parameterName, float volume)
    {
        mixerGroup.audioMixer.SetFloat(parameterName, Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * (MaxVolume - MinVolume) / 4f + MaxVolume);
    }
}