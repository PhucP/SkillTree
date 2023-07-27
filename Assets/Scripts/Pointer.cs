using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pointer : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _offset;
    private RectTransform rectTransform => GetComponent<RectTransform>();

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y - _offset, _duration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDisable()
    {
        DOTween.KillAll();
    }
}
