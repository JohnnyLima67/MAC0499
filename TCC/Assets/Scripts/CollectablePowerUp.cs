using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePowerUp : MonoBehaviour
{
    [SerializeField]
    public AbstractPowerUp powerUp;

    private bool collected = false;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player") && !collected)
        {
            collected = true;
            otherCollider.GetComponent<PowerUpManager>().equipPowerUp(powerUp);
            Debug.Log("Power Up coletado!");
        }
    }
}
