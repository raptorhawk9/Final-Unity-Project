using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTarget : Target
{
    private int pointsToBeGiven = 2;

    protected override void OnTriggerEnter(Collider other)
    {
        GivePoints(other, pointsToBeGiven);
    }
}
