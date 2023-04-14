using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        // colocar comando de morte do mob
        /*
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Die();
        }
        */
        Debug.Log("Morreu");
    }

}
