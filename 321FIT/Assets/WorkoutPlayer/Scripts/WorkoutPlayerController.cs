using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutPlayerController : MonoBehaviour 
{
	public static WorkoutPlayerController Instance;

	private WorkoutData _activeWorkout;
	private ExerciseData _activeExercise;
	private ExerciseData _nextExercise;

	[SerializeField] private GameObject _container;
	[SerializeField] private WorkoutPlayerHeader _header;
	[SerializeField] private WorkoutPlayerNotchHeader _notchHeader;
	[SerializeField] private WorkoutControlsController _workoutControls;
	[SerializeField] private WorkoutTimelineController _workoutTimeline;
	[SerializeField] private ExerciseStatsController _exerciseStats;
	[SerializeField] private ExerciseTitlesController _exerciseTitles;
	[SerializeField] private SetsDisplayController _setsDisplayController;
	[SerializeField] private TimeSliderController _timeSliderController;
	[SerializeField] private SmartCarousel _carousel;

	private int _activeExerciseIndex;
	private bool _isInPlayMode;

	[HideInInspector] public float secondsRemaining;
    [HideInInspector] public float initialSecondsBetweenExercises;

	private bool _hasHit10;
	private bool _hasHit3;
	private bool _hasHit2;
	private bool _hasHit1;

	[SerializeField] public WorkoutCompletionController _workoutCompleteMenuPrefab;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		if (Camera.main.aspect < 0.512f) 
		{
			GetComponent<RectTransform> ().offsetMin = new Vector2 (0, 80);
		}
	}

	public void Init(WorkoutData workout, int activeExerciseIndex)
	{
		_container.SetActive (true);
		_activeWorkout = workout;
		_activeExerciseIndex = activeExerciseIndex;
		_header.Init (this, workout.exerciseData.Count);
		_workoutTimeline.Init (this, _activeWorkout, _activeExerciseIndex );
		_notchHeader.Init (this, _activeWorkout);
		EstablishActiveExercise ();
		EstablishNextExercise ();
		_workoutControls.Init (this);
		_exerciseStats.Init (this);
		_exerciseTitles.Init (this);
		_carousel.Init (_activeWorkout, _activeExerciseIndex);
        initialSecondsBetweenExercises = workout.secondsBetweenExercises;
		_activeWorkout.inProgress = true;
    }

	void Update()
	{
		if(_isInPlayMode)
		{
			DeductTime ();
		}
	}

	void OnEnable()
	{
		_carousel.onEndDrag.AddListener (HandleCarouselEndDrag);
	}

	void OnDisable()
	{
		_carousel.onEndDrag.RemoveListener (HandleCarouselEndDrag);
	}

	public void Play()
	{
		_isInPlayMode = true;
		_workoutControls.ShowPlayingButtons ();

        if(_setsDisplayController.isInIntroTimerMode)
        {
            _setsDisplayController.StopIntroTimer();
        }

		_activeWorkout.inProgress = true;
    }

	public void Pause()
	{
		_isInPlayMode = false;
		_workoutControls.ShowPausedButtons ();
	}

	public void GoToPreviousSet()
	{
		ResetTimeForCurrentSet ();

		_activeExercise.totalSets ++;

		float amountComplete = ((float)_activeExercise.totalInitialSets - (float)_activeExercise.totalSets) / (float)_activeExercise.totalInitialSets;
		_workoutTimeline.UpdateActiveSegmentProgress (amountComplete);

		int activeSet = (_activeExercise.totalInitialSets - (_activeExercise.totalSets - 1));

		if (_activeExercise.totalSets > _activeExercise.totalInitialSets) 
		{
			_activeExercise.totalSets = _activeExercise.totalInitialSets;
			GoToPreviousExercise ();
		}
		else 
		{
			_setsDisplayController.ShowSetActive (activeSet);
		}

		_notchHeader.DetermineETA (_activeWorkout);

		WorkoutManager.Instance.Save();
	}

	public void GoToNextSet()
	{
		ResetTimeForCurrentSet ();

		secondsRemaining = _activeExercise.secondsToCompleteSet + 1;
		_timeSliderController.Reset ();

		_activeExercise.totalSets --;

		float amountComplete = ((float)_activeExercise.totalInitialSets - (float)_activeExercise.totalSets) / (float)_activeExercise.totalInitialSets;
		_workoutTimeline.UpdateActiveSegmentProgress (amountComplete);

		int activeSet = (_activeExercise.totalInitialSets - (_activeExercise.totalSets - 1));

		if (_activeExercise.totalSets <= 0) 
		{
			_activeExercise.totalSets = 0;
			_setsDisplayController.MarkAllSetsComplete ();
			GoToNextExercise ();
			CheckIfWorkoutComplete ();
		}
		else 
		{
			_setsDisplayController.ShowSetActive (activeSet);
		}

		_notchHeader.DetermineETA (_activeWorkout);

		WorkoutManager.Instance.Save();
	}

	public void HandleBackPressed()
	{
		if (secondsRemaining >= _activeExercise.secondsToCompleteSet - 1) 
		{
			GoToPreviousSet ();		
		}
		else 
		{
			ResetTimeForCurrentSet ();
		}

        if (_setsDisplayController.isInIntroTimerMode)
        {
            _setsDisplayController.StopIntroTimer();
        }
    }

	public void GoToPreviousExercise()
	{
		if (_activeExerciseIndex > 0) 
		{
			_activeExerciseIndex--;
			EstablishActiveExercise ();
			EstablishNextExercise ();
			Pause ();
		}

		_carousel.TweenToItemByIndex (_activeExerciseIndex);
	}

	public void GoToNextExercise()
	{
		if(_activeExerciseIndex < _activeWorkout.exerciseData.Count - 1)
		{
			_activeExerciseIndex++;
			EstablishActiveExercise ();
			EstablishNextExercise ();
			Pause ();
		}

		_carousel.TweenToItemByIndex (_activeExerciseIndex);
	}

	void EstablishActiveExercise()
	{
		if (_activeExercise != null) 
		{
			_activeExercise.isInProgress = false;
		}

		_activeExercise = _activeWorkout.exerciseData[_activeExerciseIndex];
		_activeExercise.isInProgress = true;

		if (WorkoutManager.Instance != null) 
		{
			WorkoutManager.Instance.ActiveExercise = _activeExercise;
		}

		_exerciseStats.UpdateRepValue (_activeExercise.repsPerSet);
		_exerciseStats.UpdateTimeValue (_activeExercise.secondsToCompleteSet);
		_exerciseStats.UpdateWeightValue (_activeExercise.weight);
		_exerciseTitles.UpdateActiveExerciseTitle (_activeExercise.name);

		int activeSet = (_activeExercise.totalInitialSets - (_activeExercise.totalSets - 1));
		_setsDisplayController.Init (this, _activeExercise.totalInitialSets);
		_setsDisplayController.ShowSetActive (activeSet); 

		_timeSliderController.Init (this);
		_workoutTimeline.ShowSegmentActive (_activeExerciseIndex);

		ResetTimeForCurrentSet ();

		_header.UpdateTitle (_activeExerciseIndex);
	}

	void EstablishNextExercise()
	{
		if (_activeExerciseIndex < _activeWorkout.exerciseData.Count - 1) 
		{
			ExerciseData nextExercise = _activeWorkout.exerciseData [_activeExerciseIndex + 1];
			_exerciseTitles.UpdateNextExerciseTitle (nextExercise.name, nextExercise.weight);
		}
		else 
		{
			_exerciseTitles.HideNextExerciseText ();
		}
	}

	void HandleCarouselEndDrag()
	{
		if (_activeExerciseIndex == _carousel.GetActiveIndex ()) 
		{
			return;
		}

		_activeExerciseIndex = _carousel.GetActiveIndex ();
		EstablishActiveExercise ();
		EstablishNextExercise ();
	}

	void DeductTime()
	{
		if (!_timeSliderController.selectHandler.pointerIsDown)
		{
			secondsRemaining -= Time.deltaTime;

			_timeSliderController.UpdateValue(1 - secondsRemaining/_activeExercise.secondsToCompleteSet);
		}

		_exerciseStats.UpdateTimeValue ((int)secondsRemaining);

		HandleTimerEnding ();
	}

	public void UpdateSecondsRemainingViaSlider(float value)
	{
		float newSecondsRemaining = (1 - value) * _activeExercise.secondsToCompleteSet;
		secondsRemaining = newSecondsRemaining;
		_exerciseStats.UpdateTimeValue ((int)newSecondsRemaining);
	}

	void ResetTimeForCurrentSet()
	{
		secondsRemaining = _activeExercise.secondsToCompleteSet + 1;
		_timeSliderController.Reset ();
	}

	public void Exit()
	{
		Pause ();
		_container.SetActive (false);
	}

	public void Refresh()
	{
		_activeExercise = WorkoutManager.Instance.ActiveExercise;
		EstablishActiveExercise ();
	}

	public void Refresh(int currentSecRemaining, int completedSets)
	{
		_activeExercise = WorkoutManager.Instance.ActiveExercise;

		if (completedSets < _activeExercise.totalInitialSets)
		{
			_activeExercise.totalSets = _activeExercise.totalInitialSets - completedSets;
		}
		else 
		{
			_activeExercise.totalSets = 0;
		}

		EstablishActiveExercise ();

		if (currentSecRemaining < _activeExercise.secondsToCompleteSet)
		{
			secondsRemaining = currentSecRemaining;
		}
	}

	void PlayCountDownBeep()
	{
		SoundManager.Instance.PlayCountDownBeep ();
	}

	void HandleTimerHitting0()
	{
		SoundManager.Instance.PlayLevelUpSound ();
		GoToNextSet();
		_hasHit10 = false;
		_hasHit3 = false;
		_hasHit2 = false;
		_hasHit1 = false;
	}

	void HandleTimerEnding()
	{
		if (_activeWorkout.hasTenSecTimer && !_hasHit10 && secondsRemaining < 10)
		{
			SoundManager.Instance.Play10SecWarning ();
			_hasHit10 = true;
		}
		else if (!_hasHit3 && secondsRemaining < 3)
		{
            PlayCountDownBeep ();
            //SoundManager.Instance.PlayRobo3();
            _hasHit3 = true;
		}
		else if (!_hasHit2 && secondsRemaining < 2)
		{
			PlayCountDownBeep ();
            //SoundManager.Instance.PlayRobo2();
            _hasHit2 = true;
		}
		else if (!_hasHit1 && secondsRemaining < 1)
		{
			PlayCountDownBeep ();
            //SoundManager.Instance.PlayRobo1();
            _hasHit1 = true;
		}
		else if(secondsRemaining < 0)
		{
			HandleTimerHitting0 ();
		}
	}

	public int GetAmountOfCompleteSets()
	{
		return _activeExercise.totalInitialSets - _activeExercise.totalSets;
	}

	public WorkoutData GetActiveWorkout()
	{
		return _activeWorkout;
	}

	bool CheckIfWorkoutComplete()
	{
		bool isComplete = true;

		foreach (ExerciseData exercise in _activeWorkout.exerciseData) 
		{
			if (exercise.totalSets > 0) 
			{
				isComplete = false;
				return isComplete;
				break;
			}
		}

		_header.ShowWorkoutComplete ();

		WorkoutCompletionController workoutCompleteMenu = Instantiate (_workoutCompleteMenuPrefab);
		workoutCompleteMenu.Init ();
		//SoundManager.Instance.PlayAirHorn ();

		return isComplete;
	}
}
