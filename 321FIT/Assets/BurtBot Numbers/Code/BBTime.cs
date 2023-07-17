using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BBTime : MonoBehaviour
{
    public Transform threeDigitPosition;
    public Transform fourDigitPosition;

    public BBNumber digit1;
    public BBNumber digit2;
    public BBNumber digit3;
    public BBNumber digit4;

    public void DisplaySeconds(int seconds)
    {
        if (seconds < 10)
        {
            digit1.ShowNumber(seconds);
            digit2.Show0();
        }
        else
        {

            int firstDigit = (int)(seconds.ToString()[0]) - 48;
            int secondDigit = (int)(seconds.ToString()[1]) - 48;

            digit1.ShowNumber(secondDigit);
            digit2.ShowNumber(firstDigit);
        }
    }

    public void DisplayMinutes(int minutes)
    {
        if (minutes < 10)
        {
            //transform.DOMoveX(threeDigitPosition.position.x, 0.5f);
            digit3.ShowNumber(minutes);
            digit4.ShowNull();
        }
        else
        {
            //transform.DOMove(fourDigitPosition.position, 0.5f);
            int firstDigit = (int)(minutes.ToString()[0]) - 48;
            int secondDigit = (int)(minutes.ToString()[1]) - 48;

            digit3.ShowNumber(secondDigit);
            digit4.ShowAlt1();
        }
    }
}
