using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco_planta : MonoBehaviour
{
    private HittableBehaviour collidingEntity;
    [SerializeField] float damage = 10.0f;

    void OnTriggerStay2D(Collider2D col)
    {
        collidingEntity = col.gameObject.GetComponent<HittableBehaviour>();
        if (col.CompareTag("Player") && collidingEntity != null)
            collidingEntity.TakeDamage(damage);
    }
}
