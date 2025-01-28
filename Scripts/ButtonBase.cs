using UnityEngine;

public abstract class ButtonBase<T> : MonoBehaviour
{
    [SerializeField] private AudioSource _clickSound;

    public virtual void ClickButton()
    {
        _clickSound.Play();
    }
}