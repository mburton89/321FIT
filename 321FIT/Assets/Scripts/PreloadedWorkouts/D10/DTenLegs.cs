using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTenLegs : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.workoutType = WorkoutType.squatRack;

        workoutData.name = "D10 Legs";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 600, 1, 1, 0, ExerciseType.jogInPlace);
        workoutData.exerciseData.Add(cardio);

        ExerciseData squatJumps = new ExerciseData();
        squatJumps.Init("Squat Jumps", 60, 3, 10, 0, ExerciseType.squatJumps);
        workoutData.exerciseData.Add(squatJumps);

        ExerciseData squats = new ExerciseData();
        squats.Init("Squats", 120, 5, 5, 0, ExerciseType.squats);
        workoutData.exerciseData.Add(squats);

        ExerciseData deadlift = new ExerciseData();
        deadlift.Init("Deadlift", 120, 3, 10, 0, ExerciseType.deadlifts);
        workoutData.exerciseData.Add(deadlift);

        ExerciseData lunges = new ExerciseData();
        lunges.Init("Lunges", 90, 3, 10, 0, ExerciseType.lunges);
        workoutData.exerciseData.Add(lunges);

        ExerciseData calfRaises = new ExerciseData();
        calfRaises.Init("Calf Raises", 60, 3, 10, 0, ExerciseType.calfRaises);
        workoutData.exerciseData.Add(calfRaises);

        ExerciseData obliqueSideRaisesLeft = new ExerciseData();
        obliqueSideRaisesLeft.Init("Oblique Side Raises - Left Side", 60, 3, 10, 0, ExerciseType.obliqueSideRaises);
        workoutData.exerciseData.Add(obliqueSideRaisesLeft);

        ExerciseData obliqueSideRaisesRight = new ExerciseData();
        obliqueSideRaisesRight.Init("Oblique Side Raises - Right Side", 60, 3, 10, 0, ExerciseType.obliqueSideRaises);
        workoutData.exerciseData.Add(obliqueSideRaisesRight);

        ExerciseData jog = new ExerciseData();
        jog.Init("Jog", 600, 1, 1, 0, ExerciseType.jogInPlace);
        workoutData.exerciseData.Add(jog);

        workoutData.secondsBetweenExercises = 60;

        return workoutData;
    }
}
