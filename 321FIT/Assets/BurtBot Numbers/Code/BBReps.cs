using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class BBReps : MonoBehaviour
{
    public Transform twoDigitPosition;
    public Transform threeDigitPosition;

    public BBNumber digit1;
    public BBNumber digit2;

    public void DisplayNumber(int number)
    {
        if (number < 10)
        {
            transform.DOMoveX(twoDigitPosition.position.x, 0.5f);
            digit1.ShowNumber(number);
            digit2.ShowNull();
        }
        else
        {
            transform.DOMoveX(threeDigitPosition.position.x, 0.5f);

            int firstDigit = (int)(number.ToString()[0]) - 48;
            int secondDigit = (int)(number.ToString()[1]) - 48;

            print(firstDigit);
            print(secondDigit);

            digit1.ShowNumber(firstDigit);
            digit2.ShowNumber(secondDigit);
        }
    }
}
