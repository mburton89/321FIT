﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondsEditRow : StatEditRow 
{
	public void Init(EditExerciseView editExerciseView)
	{
		controller = editExerciseView;
		value = controller.currentExerciseData.secondsToCompleteSet;
		numberInput.text = value.ToString();
		labelString = "Sec: ";
		UpdateStatView ();
	}

	void OnEnable () 
	{
		lessButton.onShortClick.AddListener (Decrement);
		moreButton.onShortClick.AddListener (Increment);
		numberInput.onValueChanged.AddListener(delegate{HandleInputFieldSubmitted();});
		numberInput.onSubmit.AddListener(delegate{HandleInputFieldSubmitted();});
	}

	void OnDisable () 
	{
		lessButton.onShortClick.RemoveListener (Decrement);
		moreButton.onShortClick.RemoveListener (Increment);
		numberInput.onValueChanged.RemoveListener(delegate{HandleInputFieldSubmitted();});
		numberInput.onSubmit.RemoveListener(delegate{HandleInputFieldSubmitted();});
	}

	public void HandleInputFieldSubmitted()
	{
        Debug.Log("numberInput.text " + numberInput.text);

        int newValue = 60;

        try
        {
            newValue = int.Parse(numberInput.text); //TODO this crashes iPhone!!!!!!!!
        }
        catch (Exception ex)
        {
            Debug.Log("EXCEPTION: " + ex);
        }

        if (string.IsNullOrEmpty(numberInput.text) ||  newValue < 1)
		{
			value = 1;
			numberInput.text = value.ToString();
		}
		else
		{
			value = newValue;
		}

		UpdateData ();
	}

	void Decrement()
	{
		if (value > 6) 
		{
			value = value - 5;			
		}

		numberInput.text = value.ToString();
		UpdateData ();
		SoundManager.Instance.PlayButtonPressSound ();
	}

	void Increment()
	{
		if (value < 995) 
		{
			value = value + 5;			
		}

		numberInput.text = value.ToString();
		UpdateData ();
		SoundManager.Instance.PlayButtonPressSound ();
	}

	void UpdateData()
	{
		controller.currentExerciseData.secondsToCompleteSet = value;

		if (controller.currentExerciseMenuItem != null)
		{
			controller.currentExerciseMenuItem.UpdateStatsText();
		}

		UpdateStatView ();
		WorkoutManager.Instance.Save();
	}

	void UpdateStatView()
	{
		//Footer.Instance.UpdateTitle (labelString);
	}
}
