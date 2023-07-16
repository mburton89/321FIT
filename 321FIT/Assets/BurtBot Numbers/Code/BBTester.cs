using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBTester : MonoBehaviour
{
    public BBNumber bbNumber;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bbNumber.Show1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bbNumber.Show2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bbNumber.Show3();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            bbNumber.Show4();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            bbNumber.Show5();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            bbNumber.Show6();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            bbNumber.Show7();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            bbNumber.Show8();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            bbNumber.Show9();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            bbNumber.Show0();
        }
    }
}
