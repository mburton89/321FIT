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

    public enum WorkoutType
    {
        cardio,
        upperBody,
        lowerBody,
        fullBody
    }

    public WorkoutType currentWorkoutType;

    private void Start()
    {
        randomWorkout.name = "WOD " + DateTime.Now.Month + "/" + DateTime.Now.Day;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            DetermineViableExercises();
            GenerateRandomWorkout();
        }
    }

    void DetermineViableExercises()
    {
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

    void GenerateRandomWorkout()
    {
        //Check minutes remaining
        //if minutes remaining > 0, add another random exercise
        //get random int between 0 and length of viable workouts
        //if int is same index as exercise that has already been used, get new random int
        //else add viableExercises[randomInt] to randomWorkout

        randomWorkout = new WorkoutData();
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
    }

    public void UpdateMinutes(float minutes)
    {
        desiredMinutesInWorkout = (int)minutes;
    }

    public void UpdateDifficulty(float difficulty)
    {
        desiredDifficulty = (int)difficulty;
    }

    //public bool hasAbWheel;
    //public bool hasRunningPath;
    //public bool hasDumbells;
    //public bool hasSquatRack;
    //public bool hasCablesOrBands;
    //public bool hasBench;
    //public bool hasPullUpBar;
    //public bool hasRowMachine;
    //public bool hasDipsBar;

    public void UpdateHasAbWheel(bool isTrue)
    {
        hasAbWheel = isTrue;
    }
}
