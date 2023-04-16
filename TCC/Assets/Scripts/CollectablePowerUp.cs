using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePowerUp : MonoBehaviour
{
    public AbstractPowerUp powerUp;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.equipPowerUp(powerUp);
        }
    }
}
