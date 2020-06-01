using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IPhoneMover : MonoBehaviour
{
    public static IPhoneMover Instance;

    [SerializeField] private Transform iPhone;
    [SerializeField] private Transform scanlines;

    public enum IPhonePosition { left, center, right };

    private IPhonePosition _currentPosition;

    [SerializeField] private float _speed;
    [SerializeField] private float _distanceToMove;
    [SerializeField] private float _zoomedInAmount;

    private float _initialXPosition;
    private float _initialXPositionForScanlines;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _currentPosition = IPhonePosition.center;
        _initialXPosition = iPhone.transform.position.x;
        _initialXPositionForScanlines = scanlines.transform.position.x;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    if (_currentPosition == IPhonePosition.right)
        //    {
        //        MoveToCenter();
        //    }
        //    else if (_currentPosition == IPhonePosition.center)
        //    {
        //        MoveToLeft();
        //    }
        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    if (_currentPosition == IPhonePosition.left)
        //    {
        //        MoveToCenter();
        //    }
        //    else if (_currentPosition == IPhonePosition.center)
        //    {
        //        MoveToRight();
        //    }
        //}
        //else if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    ZoomIn();
        //}
        //else if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    ZoomOut();
        //}

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveToPos2();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveToPos1();
        }
    }

    private void MoveToCenter()
    {
        iPhone.DOMoveX(_initialXPosition, _speed);
        scanlines.DOMoveX(_initialXPositionForScanlines, _speed);
        _currentPosition = IPhonePosition.center;
    }

    private void MoveToLeft()
    {
        iPhone.DOMoveX(_initialXPosition - _distanceToMove, _speed);
        _currentPosition = IPhonePosition.left;
    }

    private void MoveToRight()
    {
        iPhone.DOMoveX(_initialXPosition + _distanceToMove, _speed);
        _currentPosition = IPhonePosition.right;
    }

    public void MoveToPos1()
    {
        iPhone.DOScale(1, _speed).OnComplete(MoveToCenter);
        scanlines.DOScale(1.05f, _speed).OnComplete(MoveToCenter);
    }

    public void MoveToPos2()
    {
        iPhone.DOMoveX(_initialXPosition - _distanceToMove, _speed).OnComplete(ZoomIn);
        scanlines.DOMoveX(_initialXPositionForScanlines - _distanceToMove, _speed).OnComplete(ZoomIn);
    }

    void ZoomOut()
    {
        iPhone.DOScale(1, _speed);
        scanlines.DOScale(1.05f, _speed);
    }

    void ZoomIn()
    {
        iPhone.DOScale(_zoomedInAmount, _speed);
        scanlines.DOScale(_zoomedInAmount, _speed);
    }
}
