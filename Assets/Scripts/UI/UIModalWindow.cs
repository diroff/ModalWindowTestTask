using UnityEngine;

public class UIModalWindow : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public virtual void EnablePanel()
    {
        _panel.SetActive(true);
    }

    public virtual void DisablePanel()
    {
        _panel.SetActive(false);
    }
}