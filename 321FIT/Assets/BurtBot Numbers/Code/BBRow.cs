using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BBRow : MonoBehaviour
{
    public BBNumber bbNumber;

    public Image dotLeft;
    public Image dotMiddle;
    public Image dotRight;

    private void Start()
    {
        dotLeft.color = ColorManager.Instance.ActiveColorLight;
        dotMiddle.color = ColorManager.Instance.ActiveColorLight;
        dotRight.color = ColorManager.Instance.ActiveColorLight;
    }

    public void ShowLeftDot()
    {
        dotLeft.rectTransform.DOSizeDelta(bbNumber.dotSize, bbNumber.secondsToAnimate);
        dotMiddle.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
        dotRight.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
    }

    public void ShowRightDot()
    {
        dotLeft.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
        dotMiddle.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
        dotRight.rectTransform.DOSizeDelta(bbNumber.dotSize, bbNumber.secondsToAnimate);
    }

    public void ShowLeftAndRightDot()
    {
        dotLeft.rectTransform.DOSizeDelta(bbNumber.dotSize, bbNumber.secondsToAnimate);
        dotMiddle.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
        dotRight.rectTransform.DOSizeDelta(bbNumber.dotSize, bbNumber.secondsToAnimate);
    }

    public void ShowMiddleDot()
    {
        dotLeft.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
        dotMiddle.rectTransform.DOSizeDelta(bbNumber.dotSize, bbNumber.secondsToAnimate);
        dotRight.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
    }

    public void ShowLeftLine()
    {
        dotLeft.rectTransform.DOSizeDelta(bbNumber.leftLineSize, bbNumber.secondsToAnimate);
        dotMiddle.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
        dotRight.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
    }

    public void ShowFullLine()
    {
        dotLeft.rectTransform.DOSizeDelta(bbNumber.fullLineSize, bbNumber.secondsToAnimate);
        dotMiddle.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
        dotRight.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
    }

    public void ShowNull()
    {
        dotLeft.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
        dotMiddle.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
        dotRight.rectTransform.DOSizeDelta(bbNumber.emptyDotSize, bbNumber.secondsToAnimate);
    }
}

