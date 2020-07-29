using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomWODGeneratorMenu : MonoBehaviour
{
    public static RandomWODGeneratorMenu Instance;

    [SerializeField] private RandomWorkoutGenerator _generator;

    [SerializeField] private GameObject _container;
    [SerializeField] private Button _clickOverlay;

    [SerializeField] private TextMeshProUGUI _minutesLabel;
    [SerializeField] private TextMeshProUGUI _difficultyLabel;

    [SerializeField] private Slider _minutesSlider;
    [SerializeField] private Slider _difficultySlider;
    [SerializeField] private Toggle _hasAbWheel;
    [SerializeField] private Toggle _hasBench;
    [SerializeField] private Toggle _hasDipsBar;
    [SerializeField] private Toggle _hasDumbbells;
    [SerializeField] private Toggle _hasSquatRack;
    [SerializeField] private Toggle _hasPullUpBar;
    [SerializeField] private Toggle _hasBands;
    [SerializeField] private Toggle _hasRowMachine;

    [SerializeField] private ShadowButton _generateWorkoutButton;

    [SerializeField] List<Image> _colorImages;
    [SerializeField] List<TextMeshProUGUI> _texts;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        foreach (Image colorImage in _colorImages)
        {
            colorImage.color = ColorManager.Instance.ActiveColorLight;
        }

        foreach (TextMeshProUGUI text in _texts)
        {
            text.color = ColorManager.Instance.ActiveColorLight;
        }

        _hasAbWheel.isOn = _generator.hasAbWheel;
        _hasBench.isOn = _generator.hasBench;
        _hasDipsBar.isOn = _generator.hasDipsBar;
        _hasDumbbells.isOn = _generator.hasDumbells;
        _hasSquatRack.isOn = _generator.hasSquatRack;
        _hasPullUpBar.isOn = _generator.hasPullUpBar;
        _hasBands.isOn = _generator.hasCablesOrBands;
        _hasRowMachine.isOn = _generator.hasRowMachine;
        _minutesSlider.value = _generator.desiredMinutesInWorkout;
        _difficultySlider.value = _generator.desiredDifficulty;
    }

    void OnEnable()
    {
        _clickOverlay.onClick.AddListener(Close);
        _minutesSlider.onValueChanged.AddListener(UpdateMinutes);
        _difficultySlider.onValueChanged.AddListener(UpdateDifficulty);
        _hasAbWheel.onValueChanged.AddListener(_generator.UpdateHasAbWheel);
        _hasBench.onValueChanged.AddListener(_generator.UpdateHasBench);
        _hasDipsBar.onValueChanged.AddListener(_generator.UpdateHasDipsBar);
        _hasDumbbells.onValueChanged.AddListener(_generator.UpdateHasDumbells);
        _hasSquatRack.onValueChanged.AddListener(_generator.UpdateHasSquatRack);
        _hasPullUpBar.onValueChanged.AddListener(_generator.UpdateHasPullUpBar);
        _hasBands.onValueChanged.AddListener(_generator.UpdateHasCablesOrBands);
        _hasRowMachine.onValueChanged.AddListener(_generator.UpdateHasRowMachine);
        _generateWorkoutButton.onShortClick.AddListener(GenerateWorkout);
    }

    void OnDisable()
    {
        _clickOverlay.onClick.RemoveListener(Close);
        _minutesSlider.onValueChanged.RemoveListener(UpdateMinutes);
        _difficultySlider.onValueChanged.RemoveListener(UpdateDifficulty);
        _hasAbWheel.onValueChanged.RemoveListener(_generator.UpdateHasAbWheel);
        _hasBench.onValueChanged.RemoveListener(_generator.UpdateHasBench);
        _hasDipsBar.onValueChanged.RemoveListener(_generator.UpdateHasDipsBar);
        _hasDumbbells.onValueChanged.RemoveListener(_generator.UpdateHasDumbells);
        _hasSquatRack.onValueChanged.RemoveListener(_generator.UpdateHasSquatRack);
        _hasPullUpBar.onValueChanged.RemoveListener(_generator.UpdateHasPullUpBar);
        _hasBands.onValueChanged.RemoveListener(_generator.UpdateHasCablesOrBands);
        _hasRowMachine.onValueChanged.RemoveListener(_generator.UpdateHasRowMachine);
        _generateWorkoutButton.onShortClick.RemoveListener(GenerateWorkout);
    }

    void UpdateMinutes(float minutes)
    {
        _minutesLabel.SetText("Minutes: ~" + _minutesSlider.value);
        _generator.UpdateMinutes(minutes);
    }
    void UpdateDifficulty(float difficulty)
    {
        _difficultyLabel.SetText("Difficulty: " + _difficultySlider.value);
        _generator.UpdateDifficulty(difficulty);
    }

    void GenerateWorkout()
    {
        Close();
        _generator.GenerateRandomWorkout();
    }

    public void Open()
    {
        _container.SetActive(true);
    }

    void Close()
    {
        _container.SetActive(false);
    }
}
