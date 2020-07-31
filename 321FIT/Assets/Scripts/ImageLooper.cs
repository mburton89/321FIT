using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLooper : MonoBehaviour
{
    public float frameRate;
    public List<Sprite> frames;
    public Image activeFrame;
    private int _frameIndex;

    void Start()
    {
        Play();
    }

    public void Play()
    {
        _frameIndex = 0;
        StopCoroutine("playAnimationCo");
        StartCoroutine("playAnimationCo");
    }

    public void Stop()
    {
        StopCoroutine("playAnimationCo");
    }

    private IEnumerator playAnimationCo()
    {
        ShowNextFrame();
        yield return new WaitForSeconds(frameRate);
        StartCoroutine("playAnimationCo");
    }

    void ShowNextFrame()
    {
        if (_frameIndex >= frames.Count)
        {
            _frameIndex = 0;
        }

        activeFrame.sprite = frames[_frameIndex];
        _frameIndex++;
    }
}
