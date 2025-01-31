using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderStandart : MonoBehaviour 
{
    private const float MaxVolumeSound = 0f;
    private const float MinVolumeSound = -80f;

    private const float MaxVolumeSlider = 1f;
    private const float MinVolumeSlider = 0f;

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _parameterName;

    private void Awake()
    {
        _slider.maxValue = MaxVolumeSlider;
        _slider.minValue = MinVolumeSlider;
        _slider.value = _slider.maxValue;

        ChangeVolume(_slider.value);
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {   
        SetVolume(_mixer, _parameterName, volume);
    }

    private void SetVolume(AudioMixerGroup mixerGroup, string parameterName, float volume)
    {
        if (volume > 0)
        {
            float clampedVolume = Mathf.Clamp(volume, MinVolumeSlider, MaxVolumeSlider);
            float logValue = Mathf.Log10(clampedVolume);
            float volumeRange = MaxVolumeSound - MinVolumeSound;
            float normalizedValue = logValue * volumeRange / 4f;
            float value = normalizedValue + MaxVolumeSound;
            mixerGroup.audioMixer.SetFloat(parameterName, value);
        }
        else 
        {
            mixerGroup.audioMixer.SetFloat(parameterName, MinVolumeSound);
        }
    }
}