using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractPowerUp : MonoBehaviour
{
    public int manaCost;
    public virtual void Use() { }
}
