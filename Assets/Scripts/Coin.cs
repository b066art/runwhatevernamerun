using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private float animDuration;

    [SerializeField]
    private Ease animEase;

    void Start()
    {
        transform
            .DOMoveY(1.1f, animDuration)
            .SetEase(animEase)
            .SetLoops(-1, LoopType.Yoyo);
        transform
            .DORotate(Vector3.forward, animDuration)
            .SetEase(animEase)
            .SetLoops(-1, LoopType.Yoyo);
    }

    void OnDestroy()
    {
        DOTween.Kill(transform);
    }
}
