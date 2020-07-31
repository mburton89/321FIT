using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WODIcon : MonoBehaviour
{
    [SerializeField] private Transform _minutesHand;
    [SerializeField] private Transform _hoursHand;
    [SerializeField] private float _speed;
    private Vector3 _rotation;

    private void Start()
    {
        _rotation = new Vector3(0, 0, 1);

        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            image.color = ColorManager.Instance.ActiveColorLight;
        }
    }

    void Update()
    {
        _minutesHand.Rotate(_rotation * _speed);
        _hoursHand.Rotate(_rotation * _speed/12);
    }
}
