using UnityEngine;
using UnityEngine.Events;

public class UIModalWindow : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public UnityAction<bool> WindowStateChaged;

    public virtual void EnablePanel()
    {
        _panel.SetActive(true);
        WindowStateChaged?.Invoke(true);
    }

    public virtual void DisablePanel()
    {
        _panel.SetActive(false);
        WindowStateChaged?.Invoke(false);
    }
}