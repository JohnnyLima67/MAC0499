using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco_planta : MonoBehaviour
{
    private bool colidindo;

    void OnCollisionEnter2D(Collision2D col){
        // colocar comando de dano do mob
        /*
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage();
        }
        */
        colidindo = true;
        
    }

    void OnCollisionExit2D(Collision2D col){
        colidindo = false;
    }
    
    private void Update()
    {
        if (colidindo)
        {
            // Executar a função a cada X segundos enquanto o objeto estiver colidindo
            float intervaloDeTempo = 2.0f; // Intervalo de tempo em segundos
            if (Time.time % intervaloDeTempo < Time.deltaTime)
            {
                Debug.Log("Dano"); // Função a ser chamada
            }
        }
    }
}
