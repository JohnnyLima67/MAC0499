using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco_planta : MonoBehaviour
{
    private bool colidindo;
    private HittableBehaviour collidingEntity;
    [SerializeField] float damage = 10.0f;

    void OnCollisionEnter2D(Collision2D col)
    {
        // colocar comando de dano do mob
        /*
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage();
        }
        */
        collidingEntity = col.gameObject.GetComponent<HittableBehaviour>();
        if (collidingEntity != null)
        {
            colidindo = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<HittableBehaviour>() != null)
        {
            colidindo = false;
            collidingEntity = null;
        }
    }
    
    private void Update()
    {
        if (colidindo)
        {
            // Executar a função a cada X segundos enquanto o objeto estiver colidindo
            // float intervaloDeTempo = 2.0f; // Intervalo de tempo em segundos
            // if (Time.time % intervaloDeTempo < Time.deltaTime)
            // {
            //     collidingEntity.TakeDamage(damage);
            // }
            collidingEntity.TakeDamage(damage);
        }
    }
}
