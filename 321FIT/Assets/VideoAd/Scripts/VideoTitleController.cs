using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class VideoTitleController : MonoBehaviour
{
    public static VideoTitleController Instance;
    [SerializeField] private List<TextMeshProUGUI> _texts;
    [SerializeField] private Ease ease;
    [SerializeField] private float _secondsToMove;
    [SerializeField] private float _secondsBetweenTexts;
    [SerializeField] private float _startYPos;
    private float _endYPos;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _endYPos = _texts[0].transform.position.y;
        MoveToPosition("TESTING!");
    }

    public void MoveToPosition(string excerciseName)
    {
        ResetTexts();
        SetTexts(excerciseName);
        StartCoroutine(AnimateTexts());
    }

    void SetTexts(string textString)
    {
        foreach (TextMeshProUGUI text in _texts)
        {
            text.SetText(textString);
            text.SetText(textString);
        }
    }

    void ResetTexts()
    {
        foreach (TextMeshProUGUI text in _texts)
        {
            text.transform.localPosition = new Vector3(0, _startYPos);
            text.transform.localScale = Vector3.zero;
        }
        SetTexts("");
    }

    private IEnumerator AnimateTexts()
    {
        yield return new WaitForSeconds(1.5f);

        foreach (TextMeshProUGUI text in _texts)
        {
            text.transform.DOMoveY(_endYPos, _secondsToMove).SetEase(ease);
            text.transform.DOScale(1, _secondsToMove).SetEase(ease);
            yield return new WaitForSeconds(_secondsBetweenTexts);
        }
    }
}
