using UnityEngine;
using DG.Tweening;

public class UIButtonAnimationScale : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        AnimationButtonScale();
    }

    private void AnimationButtonScale()
    {
        _transform.DOScale(1.2f, 1).SetLoops(-1, LoopType.Yoyo).SetUpdate(UpdateType.Normal, true);
    }
}
