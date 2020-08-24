using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ColorConfigurer : MonoBehaviour
{
    float m_Hue;
    float m_Saturation;
    float m_Scanlines;
    public Slider m_SliderHue, m_SliderSaturation, m_SliderScanlines;
    public ShadowButton confirmButton;
    [SerializeField] private TextMeshProUGUI[] _texts;
    [SerializeField] private Image[] _images;

    [SerializeField] private TextMeshProUGUI _headerTitle;

    [SerializeField] private TextMeshProUGUI _colorText;
    [SerializeField] private ShadowButton _previousColor;
    [SerializeField] private ShadowButton _nextColor;

    [SerializeField] private List<SelectableColor> _selectableColors;
    private int _colorIndex;

    [SerializeField] private UISelectHandler _hueSelectHandler;
    [SerializeField] private UISelectHandler _satSelectHandler;
    [SerializeField] private UISelectHandler _scanSelectHandler;

    void OnEnable()
	{
		confirmButton.onShortClick.AddListener (HandleNextButtonPressed);
        _previousColor.onShortClick.AddListener(GoToPreviousColor);
        _nextColor.onShortClick.AddListener(GoToNextColor);
        _hueSelectHandler.onPointerDown.AddListener(ShowCustom);
        _satSelectHandler.onPointerDown.AddListener(ShowCustom);
        _scanSelectHandler.onPointerDown.AddListener(ShowCustom);
    }

    void OnDisable()
	{
		confirmButton.onShortClick.RemoveListener(HandleNextButtonPressed);
        _previousColor.onShortClick.RemoveListener(GoToPreviousColor);
        _nextColor.onShortClick.RemoveListener(GoToNextColor);
        _hueSelectHandler.onPointerDown.RemoveListener(ShowCustom);
        _satSelectHandler.onPointerDown.RemoveListener(ShowCustom);
        _scanSelectHandler.onPointerDown.RemoveListener(ShowCustom);
    }

	void Start()
	{
		m_SliderHue.maxValue = 1;
		m_SliderSaturation.maxValue = 1;
		m_SliderScanlines.maxValue = 1;

		m_SliderHue.minValue = 0;
		m_SliderSaturation.minValue = 0;
		m_SliderScanlines.minValue = 0;

        _colorIndex = PlayerPrefs.GetInt("selectableColor");

        if (_colorIndex == -1)
        {
            m_SliderHue.value = PlayerPrefs.GetFloat("hue");
            m_SliderSaturation.value = PlayerPrefs.GetFloat("saturation");
            m_SliderScanlines.value = PlayerPrefs.GetFloat("scanlines");
            ShowCustom();
        }
        else
        {
            UpdateColor();
        }

        _headerTitle.text = PlayerPrefs.GetString("userTitle");
	}

	void Update()
	{
		m_Hue = m_SliderHue.value;
		m_Saturation = m_SliderSaturation.value;
		m_Scanlines = m_SliderScanlines.value;
		DisplayColors ();
	}

	void HandleNextButtonPressed()
	{
        PlayerPrefs.SetFloat ("hue", m_Hue);
		PlayerPrefs.SetFloat ("saturation", m_Saturation);
		PlayerPrefs.SetFloat ("scanlines", m_Scanlines);
		SceneManager.LoadScene (1);
	}

	void DisplayColors()
	{
		foreach (TextMeshProUGUI text in _texts) {
			text.color = Color.HSVToRGB(m_Hue, m_Saturation, 1);
		}

		foreach (Image image in _images) {
			image.color = Color.HSVToRGB(m_Hue, m_Saturation, 1);
		}

		ScanlineController.Instance.SetUpScanlines (m_Scanlines);
	}

    private void GoToNextColor()
    {
        if (_colorIndex < _selectableColors.Count - 1)
        {
            _colorIndex++;
        }
        else
        {
            _colorIndex = 0;
        }
        PlayerPrefs.SetInt("selectableColor", _colorIndex);
        UpdateColor();
    }

    private void GoToPreviousColor()
    {
        if (_colorIndex > 0)
        {
            _colorIndex--;
        }
        else
        {
            _colorIndex = _selectableColors.Count - 1;
        }
        PlayerPrefs.SetInt("selectableColor", _colorIndex);
        UpdateColor();
    }

    void UpdateColor()
    {
        SelectableColor activeSelectableColor = _selectableColors[_colorIndex];
        _colorText.SetText(activeSelectableColor.colorName);
        m_SliderHue.value = activeSelectableColor.hue;
        m_SliderSaturation.value = activeSelectableColor.satruatrion;
        m_SliderScanlines.value = activeSelectableColor.scanlines;
    }

    void ShowCustom()
    {
        _colorText.SetText("Custom");
        PlayerPrefs.SetInt("selectableColor", -1);
    }
}
