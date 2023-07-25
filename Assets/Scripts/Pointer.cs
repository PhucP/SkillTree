using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pointer : MonoBehaviour
{
    private Sequence _sequence;
    public Vector3 _originPos;

    [SerializeField] private float _duration;
    [SerializeField] private float _offset;

    private void Awake()
    {
        _originPos = transform.position;
    }

    private void OnEnable()
    {
        transform.position = _originPos;
        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOMoveY(transform.position.y - _offset, _duration)).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDisable()
    {
        _sequence.Kill();
    }
}
