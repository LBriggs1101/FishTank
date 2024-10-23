using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeClassPeriodNumber : MonoBehaviour
{
    public ClassPeriodManager classPeriodManager;

    public void changeClassPeriod(int period)
    {
        classPeriodManager.ClassPeriod = period;
    }
}
