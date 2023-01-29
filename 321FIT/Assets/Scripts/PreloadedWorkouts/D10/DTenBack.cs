using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTenBack : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.workoutType = WorkoutType.pullupBar;

        workoutData.name = "D10 Back & Biceps";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 600, 1, 1, 0, ExerciseType.jogInPlace);
        workoutData.exerciseData.Add(cardio);

        ExerciseData chinUps = new ExerciseData();
        chinUps.Init("Pull Ups", 90, 5, 5, 0, ExerciseType.pullUps);
        workoutData.exerciseData.Add(chinUps);

        ExerciseData bentOverRows = new ExerciseData();
        bentOverRows.Init("Bent Over Rows", 90, 3, 10, 0, ExerciseType.bentOverRow);
        workoutData.exerciseData.Add(bentOverRows);

        ExerciseData straightLegDeadlift = new ExerciseData();
        straightLegDeadlift.Init("Straight Leg Deadlift", 90, 3, 10, 0, ExerciseType.straightLegDeadlift);
        workoutData.exerciseData.Add(straightLegDeadlift);

        ExerciseData dbRowsLeft = new ExerciseData();
        dbRowsLeft.Init("Dumbell Rows - Left Arm", 75, 3, 10, 0, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsLeft);

        ExerciseData dbRowsRight = new ExerciseData();
        dbRowsRight.Init("Dumbell Rows - Right Arm", 75, 3, 10, 0, ExerciseType.dbRows);
        workoutData.exerciseData.Add(dbRowsRight);

        ExerciseData curls = new ExerciseData();
        curls.Init("Curls", 75, 3, 10, 0, ExerciseType.curls);
        workoutData.exerciseData.Add(curls);

        ExerciseData reverseCurls = new ExerciseData();
        reverseCurls.Init("Reverse Curls", 75, 3, 10, 0, ExerciseType.reverseCurls);
        workoutData.exerciseData.Add(reverseCurls);

        ExerciseData rowMachine = new ExerciseData();
        rowMachine.Init("Row Machine", 600, 1, 1, 0, ExerciseType.rowMachine);
        workoutData.exerciseData.Add(rowMachine);

        workoutData.secondsBetweenExercises = 60;

        return workoutData;
    }
}
