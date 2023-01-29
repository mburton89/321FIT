using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTenChest : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.workoutType = WorkoutType.benchRack;

        workoutData.name = "D10 Chest & Triceps";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 600, 1, 1, 0, ExerciseType.jogInPlace);
        workoutData.exerciseData.Add(cardio);

        ExerciseData pushups = new ExerciseData();
        pushups.Init("Pushups", 60, 3, 10, 0, ExerciseType.pushups);
        workoutData.exerciseData.Add(pushups);

        ExerciseData benchPress = new ExerciseData();
        benchPress.Init("Bench Press", 120, 5, 5, 0, ExerciseType.benchPress);
        workoutData.exerciseData.Add(benchPress);

        ExerciseData dips = new ExerciseData();
        dips.Init("Dips", 90, 3, 10, 0, ExerciseType.dips);
        workoutData.exerciseData.Add(dips);

        ExerciseData inclineBench = new ExerciseData();
        inclineBench.Init("DB Incline Bench Press", 90, 3, 10, 0, ExerciseType.inclineBench);
        workoutData.exerciseData.Add(inclineBench);

        ExerciseData flies = new ExerciseData();
        flies.Init("Flies", 75, 3, 10, 0, ExerciseType.benchPress); //TODO Update Animation... maybe
        workoutData.exerciseData.Add(flies);

        ExerciseData overheadTricepExtensions = new ExerciseData();
        overheadTricepExtensions.Init("Overhead Tricep Extensions", 75, 3, 10, 0, ExerciseType.overheadTricepExtensions);
        workoutData.exerciseData.Add(overheadTricepExtensions);

        ExerciseData abWheel = new ExerciseData();
        abWheel.Init("Ab Wheel", 60, 3, 5, 0, ExerciseType.abWheel);
        workoutData.exerciseData.Add(abWheel);

        ExerciseData boxJumps = new ExerciseData();
        boxJumps.Init("Box Jumps", 60, 10, 0, 0, ExerciseType.boxJumps);
        workoutData.exerciseData.Add(boxJumps);

        workoutData.secondsBetweenExercises = 60;

        return workoutData;
    }
}
