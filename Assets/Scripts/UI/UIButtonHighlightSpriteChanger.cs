using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonHighlightSpriteChanger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite _pressedSprite;
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    private Sprite _normalSprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_button.IsInteractable())
            return;

        _normalSprite = _image.sprite;

        _image.sprite = _pressedSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_button.IsInteractable())
            return;

        _image.sprite = _normalSprite;
    }
}