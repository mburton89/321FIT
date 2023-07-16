using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBNumber : MonoBehaviour
{
    public BBRow topLine;
    public BBRow topDot1;
    public BBRow topDot2;
    public BBRow middleLine;
    public BBRow bottomDot1;
    public BBRow bottomDot2;
    public BBRow bottomLine;

    public float secondsToAnimate;

    //public Transform dotLeftXPosition;
    //public Transform dotRightXPosition;
    //public Transform dotMiddleXPosition;
    //public float dotLeftLineXPosition;

    public Vector2 emptyDotSize;
    public Vector2 dotSize;
    public Vector2 leftLineSize;
    public Vector2 fullLineSize;

    public void ShowNumber(int number)
    {
        if (number == 0)
        {
            Show0();
        }
        else if (number == 1)
        {
            Show1();
        }
        else if (number == 2)
        {
            Show2();
        }
        else if (number == 3)
        {
            Show3();
        }
        else if (number == 4)
        {
            Show4();
        }
        else if (number == 5)
        {
            Show5();
        }
        else if (number == 6)
        {
            Show6();
        }
        else if (number == 7)
        {
            Show7();
        }
        else if (number == 8)
        {
            Show8();
        }
        else if (number == 9)
        {
            Show9();
        }
    }

    public void Show0()
    {
        topLine.ShowFullLine();
        topDot1.ShowLeftAndRightDot();
        topDot2.ShowLeftAndRightDot();
        middleLine.ShowLeftAndRightDot();
        bottomDot1.ShowLeftAndRightDot();
        bottomDot2.ShowLeftAndRightDot();
        bottomLine.ShowFullLine();
    }

    public void Show1()
    {
        topLine.ShowLeftLine();
        topDot1.ShowMiddleDot();
        topDot2.ShowMiddleDot();
        middleLine.ShowMiddleDot();
        bottomDot1.ShowMiddleDot();
        bottomDot2.ShowMiddleDot();
        bottomLine.ShowFullLine();
    }

    public void ShowAlt1()
    {
        topLine.ShowRightDot();
        topDot1.ShowRightDot();
        topDot2.ShowRightDot();
        middleLine.ShowRightDot();
        bottomDot1.ShowRightDot();
        bottomDot2.ShowRightDot();
        bottomLine.ShowRightDot();
    }

    public void Show2()
    {
        topLine.ShowFullLine();
        topDot1.ShowRightDot();
        topDot2.ShowRightDot();
        middleLine.ShowFullLine();
        bottomDot1.ShowLeftDot();
        bottomDot2.ShowLeftDot();
        bottomLine.ShowFullLine();
    }

    public void Show3()
    {
        topLine.ShowFullLine();
        topDot1.ShowRightDot();
        topDot2.ShowRightDot();
        middleLine.ShowFullLine();
        bottomDot1.ShowRightDot();
        bottomDot2.ShowRightDot();
        bottomLine.ShowFullLine();
    }

    public void Show4()
    {
        topLine.ShowLeftAndRightDot();
        topDot1.ShowLeftAndRightDot();
        topDot2.ShowLeftAndRightDot();
        middleLine.ShowFullLine();
        bottomDot1.ShowRightDot();
        bottomDot2.ShowRightDot();
        bottomLine.ShowRightDot();
    }

    public void Show5()
    {
        topLine.ShowFullLine();
        topDot1.ShowLeftDot();
        topDot2.ShowLeftDot();
        middleLine.ShowFullLine();
        bottomDot1.ShowRightDot();
        bottomDot2.ShowRightDot();
        bottomLine.ShowFullLine();
    }

    public void Show6()
    {
        topLine.ShowLeftDot();
        topDot1.ShowLeftDot();
        topDot2.ShowLeftDot();
        middleLine.ShowFullLine();
        bottomDot1.ShowLeftAndRightDot();
        bottomDot2.ShowLeftAndRightDot();
        bottomLine.ShowFullLine();
    }

    public void Show7()
    {
        topLine.ShowFullLine();
        topDot1.ShowRightDot();
        topDot2.ShowRightDot();
        middleLine.ShowRightDot();
        bottomDot1.ShowRightDot();
        bottomDot2.ShowRightDot();
        bottomLine.ShowRightDot();
    }

    public void Show8()
    {
        topLine.ShowFullLine();
        topDot1.ShowLeftAndRightDot();
        topDot2.ShowLeftAndRightDot();
        middleLine.ShowFullLine();
        bottomDot1.ShowLeftAndRightDot();
        bottomDot2.ShowLeftAndRightDot();
        bottomLine.ShowFullLine();
    }

    public void Show9()
    {
        topLine.ShowFullLine();
        topDot1.ShowLeftAndRightDot();
        topDot2.ShowLeftAndRightDot();
        middleLine.ShowFullLine();
        bottomDot1.ShowRightDot();
        bottomDot2.ShowRightDot();
        bottomLine.ShowRightDot();
    }

    public void ShowNull()
    {
        topLine.ShowNull();
        topDot1.ShowNull();
        topDot2.ShowNull();
        middleLine.ShowNull();
        bottomDot1.ShowNull();
        bottomDot2.ShowNull();
        bottomLine.ShowNull();
    }
}
