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

    [Range(0, 4)]
    public int desiredDifficulty;

    public bool hasAbWheel;
    public bool hasRunningPath;
    public bool hasDumbells;
    public bool hasSquatRack;
    public bool hasCablesOrBands;
    public bool hasBench;
    public bool hasPullUpBar;
    public bool hasRowMachine;
    public bool hasDipsBar;

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
        //TODO Set these via player pref
        hasAbWheel = false;
        hasRunningPath = true;
        hasDumbells = true;
        hasSquatRack = false;
        hasCablesOrBands = true;
        hasBench = true;
        hasPullUpBar = true;
        hasRowMachine = false;
        hasDipsBar = false;
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
        print("sup");
        viableExercises = new List<ExerciseData>();

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

        foreach (ExerciseData exerciseData in WorkoutGenerator.Instance.preloadedExercises)
        {
            if(nonviableExercises.Contains(exerciseData))
            {
                print(exerciseData.name + " not allowed");
            }
            else
            {
                viableExercises.Add(exerciseData);
            }
        }
    }

    public void GenerateRandomWorkout()
    {
        WorkoutPanel[] workoutPanels = FindObjectsOfType<WorkoutPanel>(); //TODO this is gross and spensive

        foreach (WorkoutPanel workoutPanel in workoutPanels)
        { 
            if(workoutPanel.workoutData.workoutType == WorkoutType.wod)
            {
                AreYouSurePanel.Instance.DeleteWorkout(workoutPanel);
            }
        }

        DetermineViableExercises();

        randomWorkout = new WorkoutData();
        string newWorkoutName = "WOD " + DateTime.Now.Month + "/" + DateTime.Now.Day;
        randomWorkout.name = randomWorkout.name = newWorkoutName;
        randomWorkout.workoutType = WorkoutType.wod; //TODO use WOD icon
        randomWorkout.secondsBetweenExercises = 60; //TODO Change based on difficulty
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
    }

    public void UpdateDifficulty(float difficulty)
    {
        desiredDifficulty = (int)difficulty;
    }

    public void UpdateHasAbWheel(bool isTrue)
    {
        hasAbWheel = isTrue;
    }

    public void UpdateHasRunningPath(bool isTrue)
    {
        hasRunningPath = isTrue;
    }

    public void UpdateHasDumbells(bool isTrue)
    {
        hasDumbells = isTrue;
    }

    public void UpdateHasSquatRack(bool isTrue)
    {
        hasSquatRack = isTrue;
    }

    public void UpdateHasCablesOrBands(bool isTrue)
    {
        hasCablesOrBands = isTrue;
    }

    public void UpdateHasBench(bool isTrue)
    {
        hasBench = isTrue;
    }

    public void UpdateHasPullUpBar(bool isTrue)
    {
        hasPullUpBar = isTrue;
    }

    public void UpdateHasRowMachine(bool isTrue)
    {
        hasRowMachine = isTrue;
    }

    public void UpdateHasDipsBar(bool isTrue)
    {
        hasDipsBar = isTrue;
    }
}
