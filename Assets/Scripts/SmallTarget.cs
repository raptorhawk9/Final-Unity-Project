using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTarget : Target
{
    private int pointsToBeGiven = 10;

    protected override void OnTriggerEnter(Collider other)  //POLYMOPHISM
    {
        GivePoints(other, pointsToBeGiven);
    }
}
