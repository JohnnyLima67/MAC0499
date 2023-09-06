using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePowerUp : MonoBehaviour
{
    [SerializeField]
    public AbstractPowerUp powerUp;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            otherCollider.GetComponent<PowerUpManager>().equipPowerUp(powerUp);
            gameObject.SetActive(false);
        }
    }
}
