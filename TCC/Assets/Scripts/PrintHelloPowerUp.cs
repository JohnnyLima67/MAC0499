using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintHelloPowerUp : AbstractPowerUp
{
    public override void Use()
    {
        Debug.Log("Hello World");
    }
}
