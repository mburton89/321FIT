using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTenShoulders : MonoBehaviour
{
    [HideInInspector] public WorkoutData workoutData;

    public WorkoutData GetWorkoutData()
    {
        workoutData.workoutType = WorkoutType.doubleDumbell;

        workoutData.name = "D10 Shoulders";
        workoutData.exerciseData = new List<ExerciseData>();

        ExerciseData cardio = new ExerciseData();
        cardio.Init("Cardio", 600, 1, 1, 0, ExerciseType.jogInPlace);
        workoutData.exerciseData.Add(cardio);

        ExerciseData cleanPress = new ExerciseData();
        cleanPress.Init("Clean Press", 120, 5, 5, 0, ExerciseType.cleanPress);
        workoutData.exerciseData.Add(cleanPress);

        ExerciseData dbShoulderPress = new ExerciseData();
        dbShoulderPress.Init("DB Shoulder Press", 90, 3, 10, 0, ExerciseType.db_shoulder_press);
        workoutData.exerciseData.Add(dbShoulderPress);

        ExerciseData uprightRows = new ExerciseData();
        uprightRows.Init("Upright Rows", 90, 3, 10, 0, ExerciseType.uprightRows);
        workoutData.exerciseData.Add(uprightRows);

        ExerciseData shrugs = new ExerciseData();
        shrugs.Init("Shrugs", 90, 3, 10, 0, ExerciseType.shrugs);
        workoutData.exerciseData.Add(shrugs);

        ExerciseData windmills = new ExerciseData();
        windmills.Init("Windmills", 90, 3, 10, 0, ExerciseType.windmills);
        workoutData.exerciseData.Add(windmills);

        ExerciseData frontRaises = new ExerciseData();
        frontRaises.Init("Front Raises", 75, 3, 10, 0, ExerciseType.dbFrontRaises);
        workoutData.exerciseData.Add(frontRaises);

        ExerciseData sideRaises = new ExerciseData();
        sideRaises.Init("Side Raises", 75, 3, 10, 0, ExerciseType.db_side_raises);
        workoutData.exerciseData.Add(sideRaises);

        ExerciseData reverseFlies = new ExerciseData();
        reverseFlies.Init("Reverse Flies", 75, 3, 10, 0, ExerciseType.reverseFlies);
        workoutData.exerciseData.Add(reverseFlies);

        workoutData.secondsBetweenExercises = 60;

        return workoutData;
    }
}
