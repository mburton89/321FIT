using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LogoAnimationController : MonoBehaviour {

    private Image[] _allImages;
    [SerializeField] private Color _colorDim;
    [SerializeField] private Color _colorLit;
    [SerializeField] private float _secondsToWaitBeforeLit;

    void Start ()
    {
        _allImages = FindObjectsOfType<Image>();
        foreach (Image image in _allImages)
        {
            if (image.color != Color.black)
            {
                image.color = _colorDim;
            }
        }
        StartCoroutine(LightEmUp());
	}

    private IEnumerator LightEmUp()
    {
        yield return new WaitForSeconds(_secondsToWaitBeforeLit);
        LightUpColors();
    }

    public void LightUpColors()
    {
        foreach (Image image in _allImages)
        {
            if (image.color != Color.black)
            {
                image.DOColor(_colorLit, .5f);
            }
        }
    }
}
