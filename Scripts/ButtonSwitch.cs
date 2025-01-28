using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitch : ButtonBase<Button>
{
    private const string TextDisabledButton = "выкл звук";
    private const string TextEnabledButton = "вкл звук";

    [SerializeField] private TMP_Text _buttonText;

    private bool _isButtonEnabled;

    private void Awake()
    {
        _isButtonEnabled = true;
    }

    private void Start()
    {
        UpdateButtonText();
    }

    public override void ClickButton() 
    {
        base.ClickButton();
        _isButtonEnabled = !_isButtonEnabled;
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        _buttonText.text = _isButtonEnabled ? TextDisabledButton : TextEnabledButton;
    }
}