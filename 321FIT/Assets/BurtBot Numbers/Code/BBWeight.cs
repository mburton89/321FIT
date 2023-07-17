using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BBWeight : MonoBehaviour
{
    public Transform oneDigitPosition;
    public Transform twoDigitPosition;
    public Transform threeDigitPosition;

    public BBNumber digit1;
    public BBNumber digit2;
    public BBNumber digit3;

    public void DisplayNumber(int number)
    {
        if (number < 10)
        {
            transform.DOMoveX(oneDigitPosition.position.x, 0.5f);
            digit1.ShowNull();
            digit2.ShowNull();
            digit3.ShowNumber(number);
        }
        else if (number > 99)
        {
            transform.DOMoveX(threeDigitPosition.position.x, 0.5f);

            int firstDigit = (int)(number.ToString()[0]) - 48;
            int secondDigit = (int)(number.ToString()[1]) - 48;
            int thirdDigit = (int)(number.ToString()[2]) - 48;

            digit1.ShowNumber(thirdDigit);
            digit2.ShowNumber(secondDigit);
            digit3.ShowNumber(firstDigit);
        }
        else
        {
            transform.DOMoveX(twoDigitPosition.position.x, 0.5f);

            int firstDigit = (int)(number.ToString()[0]) - 48;
            int secondDigit = (int)(number.ToString()[1]) - 48;

            digit1.ShowNull();
            digit2.ShowNumber(secondDigit);
            digit3.ShowNumber(firstDigit);
        }
    }

    public void ShowNull()
    {
        digit1.ShowNull();
        digit2.ShowNull();
        digit3.ShowNull();
    }
}
