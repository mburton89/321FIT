using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWODGeneratorMenu : MonoBehaviour
{
    [SerializeField] private RandomWorkoutGenerator _generator;

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

    void OnEnable()
    {
        _minutesSlider.onValueChanged.AddListener(_generator.UpdateMinutes);
        _difficultySlider.onValueChanged.AddListener(_generator.UpdateDifficulty);
        _hasAbWheel.onValueChanged.AddListener(_generator.UpdateHasAbWheel);
    }

    void OnDisable()
    {
        _minutesSlider.onValueChanged.RemoveListener(_generator.UpdateMinutes);
        _difficultySlider.onValueChanged.RemoveListener(_generator.UpdateDifficulty);
        _hasAbWheel.onValueChanged.RemoveListener(_generator.UpdateHasAbWheel);
    }
}
