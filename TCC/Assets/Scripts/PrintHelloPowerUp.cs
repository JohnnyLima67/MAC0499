using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintHelloPowerUp : AbstractPowerUp
{
    public void Awake()
    {
        manaCost = 10;
    }
    public override void Use()
    {
        Debug.Log("Hello World");
    }
}
