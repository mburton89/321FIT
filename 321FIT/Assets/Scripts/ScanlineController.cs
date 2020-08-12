using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ScanlineController : MonoBehaviour 
{
	public static ScanlineController Instance;

	[SerializeField] private Image _scanline;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		SetUpScanlines (PlayerPrefs.GetFloat("scanlines"));

        if (SceneManager.GetActiveScene().buildIndex == 1 && PlayerPrefs.GetFloat("scanlines") == 0f)
        {
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(Fade());
        }
	}

	public void SetUpScanlines(float amount)
	{
		Color updatedColor = _scanline.color;
		_scanline.color = new Color (updatedColor.r, updatedColor.g, updatedColor.b, amount);
	}

    private IEnumerator Fade()
    {
        float duration = 1;
        _scanline.DOFade(_scanline.color.a + .18f, duration);
        yield return new WaitForSeconds(duration);
        _scanline.DOFade(_scanline.color.a - .18f, duration);
        yield return new WaitForSeconds(duration);
        StartCoroutine(Fade());
    }
}
