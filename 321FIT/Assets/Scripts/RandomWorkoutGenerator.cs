using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWorkoutGenerator : MonoBehaviour
{
    public WorkoutData randomWorkout;
    public List<ExerciseData> viableExercises;
    public List<ExerciseData> nonviableExercises;

    [Range(5, 120)]
    public int desiredMinutesInWorkout;

    [Range(0, 2)]
    public int desiredDifficulty;

    private int secondsBetweenExercises;

    public bool hasAbWheel;
    public bool hasRunningPath;
    public bool hasDumbells;
    public bool hasSquatRack;
    public bool hasCablesOrBands;
    public bool hasBench;
    public bool hasPullUpBar;
    public bool hasRowMachine;
    public bool hasDipsBar;


    private const string HAS_USED_WOD = "hasUsedWod";
    private const string WOD_MINUTES_STRING = "wodMinutes";
    private const string WOD_DIFFICULTY_STRING = "wodDifficulty";
    private const string HAS_AB_WHEEL_STRING = "hasAbWheel";
    private const string HAS_RUNNING_PATH_STRING = "hasRunningPath";
    private const string HAS_DUMBELLS_STRING = "hasDumbells";
    private const string HAS_SQUAT_RACK_STRING = "hasSquatRack";
    private const string HAS_BANDS_STRING = "hasCablesOrBands";
    private const string HAS_BENCH_STRING = "hasBench";
    private const string HAS_PULL_UPS_BAR_STRING = "hasPullUpBar";
    private const string HAS_ROW_MACHINE_STRING = "hasRowMachine";
    private const string HAS_DIPS_BAR_STRING = "hasDipsBar";

    public enum BodyGroup
    {
        cardio,
        upperBody,
        lowerBody,
        fullBody
    }

    public BodyGroup currentBodyGroup;

    private void Awake()
    {
        if (GetPlayerPrefBool(HAS_USED_WOD))
        {
            hasAbWheel = GetPlayerPrefBool(HAS_AB_WHEEL_STRING);
            hasRunningPath = GetPlayerPrefBool(HAS_RUNNING_PATH_STRING);
            hasDumbells = GetPlayerPrefBool(HAS_DUMBELLS_STRING);
            hasSquatRack = GetPlayerPrefBool(HAS_SQUAT_RACK_STRING);
            hasCablesOrBands = GetPlayerPrefBool(HAS_BANDS_STRING);
            hasBench = GetPlayerPrefBool(HAS_BENCH_STRING);
            hasPullUpBar = GetPlayerPrefBool(HAS_PULL_UPS_BAR_STRING);
            hasRowMachine = GetPlayerPrefBool(HAS_ROW_MACHINE_STRING);
            hasDipsBar = GetPlayerPrefBool(HAS_DIPS_BAR_STRING);
            desiredMinutesInWorkout = GetPlayerPrefInt(WOD_MINUTES_STRING);
            desiredDifficulty = GetPlayerPrefInt(WOD_DIFFICULTY_STRING);
        }
        else
        {
            SetPlayerPref(HAS_USED_WOD, true);
            UpdateHasAbWheel(false);
            UpdateHasBench(false);
            UpdateHasCablesOrBands(false);
            UpdateHasDipsBar(false);
            UpdateHasDumbells(true);
            UpdateHasPullUpBar(false);
            UpdateHasRowMachine(false);
            UpdateHasRunningPath(false);
            UpdateHasSquatRack(false);
            UpdateMinutes(30);
            UpdateDifficulty(1);
        }
    }

    private void Start()
    {
        GenerateRandomWorkout();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GenerateRandomWorkout();
        }
    }

    void DetermineViableExercises()
    {
        viableExercises = new List<ExerciseData>();
        nonviableExercises = new List<ExerciseData>();

        if (!hasAbWheel)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.abWheelExercise);
        }

        if (!hasRunningPath)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.runningExercise);
        }

        if (!hasDumbells)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.dbFrontRaisesExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.dbRowsExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.dbShoulderPressExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.dbSideRaisesExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.dbToeTouchesExercise);
        }

        if (!hasSquatRack)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.squatsExercise);
        }

        if (!hasCablesOrBands)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.bandsInternalExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.bandsExternalExercise);
        }

        if (!hasBench)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.benchPressExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.inclineBenchExercise);
        }

        if (!hasPullUpBar)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.pullUpsExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.chinUpsExercise);
        }

        if (!hasRowMachine)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.rowMachineExercise);
        }

        if (!hasDipsBar)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.dipsExercise);
        }

        if (!hasDipsBar || !hasPullUpBar)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.hangingKneeRaisesExercise);
        }

        if (desiredDifficulty == 2)
        {
            secondsBetweenExercises = 60;
        }
        else if (desiredDifficulty == 1)
        {
            secondsBetweenExercises = 75;
        }
        else
        {
            secondsBetweenExercises = 90;
        }

        if (desiredDifficulty < 2)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.cleansExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.cleanPressExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.deadliftsExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.abWheelExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.dipsExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.clappingPushUpsExercise);
        }

        if (desiredDifficulty < 1)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.pullUpsExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.chinUpsExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.straightLegDeadliftExercise);
            nonviableExercises.Add(WorkoutGenerator.Instance.militaryPressExercise);
        }

        if (desiredDifficulty > 0)
        {
            nonviableExercises.Add(WorkoutGenerator.Instance.modifiedPushupsExercise);
        }

        foreach (ExerciseData exerciseData in WorkoutGenerator.Instance.preloadedExercises)
        {
            if(nonviableExercises.Contains(exerciseData))
            {
                //print(exerciseData.name + " not allowed");
            }
            else
            {
                viableExercises.Add(exerciseData);
            }
        }
    }

    public void GenerateRandomWorkout()
    {
        WorkoutPanel[] workoutPanels = FindObjectsOfType<WorkoutPanel>();

        if (workoutPanels != null)
        {
            foreach (WorkoutPanel workoutPanel in workoutPanels)
            {
                if (workoutPanel.workoutData.workoutType == WorkoutType.wod)
                {
                    AreYouSurePanel.Instance.DeleteWorkout(workoutPanel);
                }
            }
        }

        DetermineViableExercises();

        randomWorkout = new WorkoutData();
        string newWorkoutName = "W.O.D. " + DateTime.Now.Month + "/" + DateTime.Now.Day;
        randomWorkout.name = randomWorkout.name = newWorkoutName;
        randomWorkout.workoutType = WorkoutType.wod;
        randomWorkout.secondsBetweenExercises = secondsBetweenExercises;
        randomWorkout.exerciseData = new List<ExerciseData>();

        while (randomWorkout.minutes < desiredMinutesInWorkout - 3)
        {
            bool foundExercise = false;
            while (!foundExercise)
            {
                int randomExerciseIndex = UnityEngine.Random.Range(0, viableExercises.Count);
                if (randomWorkout.exerciseData.Contains(viableExercises[randomExerciseIndex]))
                {
                    foundExercise = false;
                    //return;
                }
                else
                {
                    randomWorkout.exerciseData.Add(viableExercises[randomExerciseIndex]);
                    randomWorkout.EstablishMinutes();
                    foundExercise = true;
                }
            }
        }
        //Add randomWorkout to app
        WorkoutHUD.Instance.AddWorkoutPanel(randomWorkout, false);
        SoundManager.Instance.PlayButtonPressSound();
        WorkoutManager.Instance.Save();
    }

    public void UpdateMinutes(float minutes)
    {
        desiredMinutesInWorkout = (int)minutes;
        SetPlayerPref(WOD_MINUTES_STRING, desiredMinutesInWorkout);
    }

    public void UpdateDifficulty(float difficulty)
    {
        desiredDifficulty = (int)difficulty;
        SetPlayerPref(WOD_DIFFICULTY_STRING, desiredDifficulty);
    }

    public void UpdateHasAbWheel(bool isTrue)
    {
        hasAbWheel = isTrue;
        SetPlayerPref(HAS_AB_WHEEL_STRING, hasAbWheel);
    }

    public void UpdateHasRunningPath(bool isTrue)
    {
        hasRunningPath = isTrue;
        SetPlayerPref(HAS_RUNNING_PATH_STRING, hasRunningPath);
    }

    public void UpdateHasDumbells(bool isTrue)
    {
        hasDumbells = isTrue;
        SetPlayerPref(HAS_DUMBELLS_STRING, hasDumbells);
    }

    public void UpdateHasSquatRack(bool isTrue)
    {
        hasSquatRack = isTrue;
        SetPlayerPref(HAS_SQUAT_RACK_STRING, hasSquatRack);
    }

    public void UpdateHasCablesOrBands(bool isTrue)
    {
        hasCablesOrBands = isTrue;
        SetPlayerPref(HAS_BANDS_STRING, hasCablesOrBands);
    }

    public void UpdateHasBench(bool isTrue)
    {
        hasBench = isTrue;
        SetPlayerPref(HAS_BENCH_STRING, hasBench);
    }

    public void UpdateHasPullUpBar(bool isTrue)
    {
        hasPullUpBar = isTrue;
        SetPlayerPref(HAS_PULL_UPS_BAR_STRING, hasPullUpBar);
    }

    public void UpdateHasRowMachine(bool isTrue)
    {
        hasRowMachine = isTrue;
        SetPlayerPref(HAS_ROW_MACHINE_STRING, hasRowMachine);
    }

    public void UpdateHasDipsBar(bool isTrue)
    {
        hasDipsBar = isTrue;
        SetPlayerPref(HAS_DIPS_BAR_STRING, hasDipsBar);
    }

    void SetPlayerPref(string playerPref, bool isTrue)
    {
        int isTrueInt = 0;
        if (isTrue)
        {
            isTrueInt = 1;
        }
        PlayerPrefs.SetInt(playerPref, isTrueInt);
    }

    void SetPlayerPref(string playerPref, int amount)
    {
        PlayerPrefs.SetInt(playerPref, amount);
    }

    bool GetPlayerPrefBool(string playerPref)
    {
        int playerPrefInt = PlayerPrefs.GetInt(playerPref);
        if (playerPrefInt == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    int GetPlayerPrefInt(string playerPref)
    {
        return PlayerPrefs.GetInt(playerPref);
    }
}
