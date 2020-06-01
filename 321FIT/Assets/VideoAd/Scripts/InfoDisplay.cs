using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class InfoDisplay : MonoBehaviour
{
    [HideInInspector] public List<string> phrases;
    [SerializeField] private TextMeshProUGUI _info;
    private int _index;
    [SerializeField] private GameObject Arrow;
    [SerializeField] private GameObject AppStoreBadgeContainer;

    private void Awake()
    {
        phrases.Add("Customizable AF");
        phrases.Add("Juice-saving dark UI");
        phrases.Add("Download and create workouts");
        phrases.Add("Plan your exercises");
        phrases.Add("State of the art hyper realistic animations");
        phrases.Add("Let the app train you");
        phrases.Add("ETA Display");
        phrases.Add("Navigate your workout like a music player");
        phrases.Add("Log your progress");
        phrases.Add("Obtain mad gainz like a boss");
        phrases.Add("Download for free!        No catch :D");
    }

    private void Start()
    {
        //_info.SetText(phrases[0]);
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            GoToNextPhrase();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            GoToPreviousPhrase();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ShakeText();
        }
    }

    public void GoToNextPhrase()
    {
        _index++;

        if (_index > phrases.Count)
        {
            SceneManager.LoadScene(0);
        }

        if (_index == phrases.Count - 1)
        {
            AppStoreBadgeContainer.SetActive(true);
        }

        _info.SetText(phrases[_index]);

        if (_index == 6)
        {
            Arrow.SetActive(true);
        }
        else {
            Arrow.SetActive(false);
        }

        ShakeText();
    }

    public void GoToPreviousPhrase()
    {
        _index--;
        _info.SetText(phrases[_index]);
    }

    void ShakeText()
    {
        _info.transform.DOShakeScale(.25f, 1, 10, 90, true);
    }
}
