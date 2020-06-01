using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BGScroller : MonoBehaviour
{
    private RectTransform _rectTransform;

    [SerializeField] private float _scrollingSpeed;
    [SerializeField] private Image _bg;

    public float Speed;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _bg = GetComponent<Image>();
    }

    void Update()
    {
        _rectTransform.offsetMin = new Vector2(_rectTransform.offsetMin.x - _scrollingSpeed, _rectTransform.offsetMin.y);
        //_bg.material.SetColor("_Color", HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * Speed, 1), 1, 1)));
    }
}
