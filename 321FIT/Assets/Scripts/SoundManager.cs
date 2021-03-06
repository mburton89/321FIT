﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager Instance;

	public AudioClip nextSet;
	public AudioClip nextExercise;
	public AudioClip buttonPress;
	public AudioClip splashIntro;
	public AudioClip levelUp;
	public AudioClip goBack;
	public AudioClip countdownBeep;
	public AudioClip airHorn;
    public AudioClip tenSecWarning;

    public AudioClip robo3;
    public AudioClip robo2;
    public AudioClip robo1;

    public AudioSource audioSource;

	void Awake () {
		Instance = this;
	}

	public void PlayNewSetSound(){
		audioSource.clip = nextSet;
		audioSource.Play ();
	}

	public void PlayNewExerciseSound(){
		audioSource.clip = nextExercise;
		audioSource.Play ();
	}

	public void PlayButtonPressSound(){
		audioSource.clip = buttonPress;
		audioSource.Play ();
	}

	public void PlayLevelUpSound(){
		audioSource.clip = levelUp;
		audioSource.Play ();
	}

	public void PlayGoBackSound(){
		audioSource.clip = goBack;
		audioSource.Play ();
	}

	public void PlayCountDownBeep(){
		audioSource.clip = countdownBeep;
		audioSource.Play ();
	}

	public void PlayAirHorn(){
		audioSource.clip = airHorn;
		audioSource.Play ();
	}

	public void PlaySplashIntro()
	{
		audioSource.clip = splashIntro;
		audioSource.Play ();
	}

	public void Play10SecWarning()
	{
		audioSource.clip = tenSecWarning;
		audioSource.Play ();
	}

    public void PlayRobo3()
    {
        audioSource.clip = robo3;
        audioSource.Play();
    }

    public void PlayRobo2()
    {
        audioSource.clip = robo2;
        audioSource.Play();
    }

    public void PlayRobo1()
    {
        audioSource.clip = robo1;
        audioSource.Play();
    }
}
