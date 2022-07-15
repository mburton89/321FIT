using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class AppUpdatePanel : MonoBehaviour
{
    public static AppUpdatePanel Instance;

    [SerializeField] private GameObject _container;
    [SerializeField] private Transform _spinnyContainer;
    [SerializeField] List<Image> _colorImages;
    [SerializeField] List<TextMeshProUGUI> _texts;
    [SerializeField] private Button _instagramButton;
    [SerializeField] private Button _clickOverlay;
    [SerializeField] private ShadowButton _doneButton;

    [SerializeField] private List<FitBoyAnimator> _fitBoyAnimators;
    [SerializeField] private List<ExerciseType> _exerciseTypes;

    [SerializeField] private AudioSource _airHorn;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PlayerPrefs.SetInt("hasSeenUpdate", 1);
        if (PlayerPrefs.GetInt("hasSeenUpdate") != 1)
        {
            Open();
            foreach (Image colorImage in _colorImages)
            {
                colorImage.color = ColorManager.Instance.ActiveColorLight;
            }

            foreach (TextMeshProUGUI text in _texts)
            {
                text.color = ColorManager.Instance.ActiveColorLight;
            }

            for (int i = 0; i < _fitBoyAnimators.Count; i++)
            {
                _fitBoyAnimators[i].Init(_exerciseTypes[i]);
            }

            StartCoroutine(SpinCo());

            PlayerPrefs.SetInt("hasSeenUpdate", 1);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        _instagramButton.onClick.AddListener(OpenInstagram);
        _clickOverlay.onClick.AddListener(Close);
        _doneButton.onShortClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _instagramButton.onClick.RemoveListener(OpenInstagram);
        _clickOverlay.onClick.RemoveListener(Close);
        _doneButton.onShortClick.RemoveListener(Close);
    }

    public void Open()
    {
        _container.SetActive(true);
        _airHorn.Play();
    }

    void Close()
    {
        _container.SetActive(false);
    }

    void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/321fitapp/");
    }

    private IEnumerator SpinCo()
    {
        Vector3 spinAmount = new Vector3(0, 0, 1);
        float duration = 2;
        _spinnyContainer.DORotate(spinAmount, duration).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(duration);
        _spinnyContainer.DORotate(-spinAmount, duration).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(duration);
        StartCoroutine(SpinCo());
    }
}
