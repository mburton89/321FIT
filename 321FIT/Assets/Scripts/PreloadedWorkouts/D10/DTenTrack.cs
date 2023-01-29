using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTenTrack : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.workoutType = WorkoutType.heartRate;

        workoutData.name = "D10 Track";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData warmup = new ExerciseData();
        warmup.Init("Warm Up", 600, 1, 1, 0, ExerciseType.jogInPlace);
        workoutData.exerciseData.Add(warmup);

        ExerciseData fourHundredMeter = new ExerciseData();
        fourHundredMeter.Init("400 Meter Run", 300, 1, 1, 0, ExerciseType.jogInPlace);
        workoutData.exerciseData.Add(fourHundredMeter);

        ExerciseData fourtyYardDashes = new ExerciseData();
        fourtyYardDashes.Init("40 Yard Dash", 120, 4, 1, 0, ExerciseType.jogInPlace);
        workoutData.exerciseData.Add(fourtyYardDashes);

        ExerciseData twentyYardShuttle = new ExerciseData();
        twentyYardShuttle.Init("20 Yard Shuttle", 120, 4, 1, 0, ExerciseType.jogInPlace);
        workoutData.exerciseData.Add(twentyYardShuttle);

        ExerciseData verticalJump = new ExerciseData();
        verticalJump.Init("Vertical Jump", 120, 4, 5, 0, ExerciseType.squatJumps);
        workoutData.exerciseData.Add(verticalJump);

        ExerciseData broadJump = new ExerciseData();
        broadJump.Init("Broad Jump", 120, 4, 5, 0, ExerciseType.squatJumps);
        workoutData.exerciseData.Add(broadJump);

        ExerciseData eightHundredMeter = new ExerciseData();
        eightHundredMeter.Init("800 Meter Run", 400, 1, 1, 0, ExerciseType.jogInPlace);
        workoutData.exerciseData.Add(eightHundredMeter);

        workoutData.secondsBetweenExercises = 60;

        return workoutData;
    }
}
