using System.Collections;
using UnityEngine;

public class UIAnimatedModalWindow : UIModalWindow
{
    [Header("Animation settings")]
    [SerializeField] private float _animationDuration = 0.25f;
    [SerializeField] private Vector3 _initialScale = new Vector3(0.8f, 0.8f, 1f);
    [SerializeField] private GameObject _animatedPanel;

    private Vector3 _targetScale = Vector3.one;

    public override void EnablePanel()
    {
        base.EnablePanel();
        StartCoroutine(AnimatePanelScale(_initialScale, _targetScale, _animationDuration));
    }

    private IEnumerator AnimatePanelScale(Vector3 fromScale, Vector3 toScale, float duration)
    {
        float timeElapsed = 0f;

        _animatedPanel.transform.localScale = fromScale;

        while (timeElapsed < duration)
        {
            _animatedPanel.transform.localScale = Vector3.Lerp(fromScale, toScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        _animatedPanel.transform.localScale = toScale;
    }
}