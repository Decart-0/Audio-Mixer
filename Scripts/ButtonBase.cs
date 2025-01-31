using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{
    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(ClickButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickButton);
    }

    protected virtual void ClickButton()
    {
        _clickSound.Play();
    }
}