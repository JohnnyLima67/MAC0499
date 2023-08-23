using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponColliderDetector : MonoBehaviour
{
    public List<Collider2D> enemiesInWeaponRange;

    void Awake()
    {
        enemiesInWeaponRange = new List<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
            enemiesInWeaponRange.Add(col);
    }
}
