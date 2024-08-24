using UnityEngine;

public class UIModalWindow : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private bool _enabledOnStart;

    private void Start()
    {
        SetPanelState(_enabledOnStart);
    }

    public virtual void EnablePanel()
    {
        _panel.SetActive(true);
    }

    public virtual void DisablePanel()
    {
        _panel.SetActive(false);
    }

    private void SetPanelState(bool enabled)
    {
        if (enabled)
            EnablePanel();
        else
            DisablePanel();
    }
}