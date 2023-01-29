using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTenPlan : MonoBehaviour
{
    public PlanData planData;
    public DTenBack dTenBack;
    public DTenChest dTenChest;
    public DTenLegs dTenLegs;
    public DTenShoulders dTenShoulders;
    public DTenTrack dTenTrack;

    void Awake()
    {
        planData.planDifficulty = PlanDifficulty.d10;
        planData.name = "D10 Training";
        planData.description = "D10 Decathlon Training - Let's Go!";
        planData.workoutData.Add(WorkoutData.Copy(dTenBack.GetWorkoutData()));
        planData.workoutData.Add(WorkoutData.Copy(dTenChest.GetWorkoutData()));
        planData.workoutData.Add(WorkoutData.Copy(dTenLegs.GetWorkoutData()));
        planData.workoutData.Add(WorkoutData.Copy(dTenShoulders.GetWorkoutData()));
        planData.workoutData.Add(WorkoutData.Copy(dTenTrack.GetWorkoutData()));
    }
}
