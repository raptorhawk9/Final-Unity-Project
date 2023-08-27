using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumTarget : Target
{
    private int pointsToBeGiven = 3;

    protected override void OnTriggerEnter(Collider other)
    {
        GivePoints(other, pointsToBeGiven);
    }
}
