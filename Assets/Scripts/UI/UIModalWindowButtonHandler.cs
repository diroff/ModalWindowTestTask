using UnityEngine;
using UnityEngine.UI;

public class UIModalWindowButtonHandler : MonoBehaviour
{
    [SerializeField] private UIModalWindow _uiModalWindow;
    [SerializeField] private Button _openPanelButton;

    private void Awake()
    {
        _openPanelButton.onClick.AddListener(() => _uiModalWindow.EnablePanel());
    }

    private void OnEnable()
    {
        _uiModalWindow.WindowStateChaged += SetButtonState;
    }

    private void OnDisable()
    {
        _uiModalWindow.WindowStateChaged -= SetButtonState;
    }

    private void SetButtonState(bool enabled)
    {
        _openPanelButton.gameObject.SetActive(!enabled);
    }
}