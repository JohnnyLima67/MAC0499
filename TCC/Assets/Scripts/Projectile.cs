using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float projectileDuration;

    float time = 0.0f;

    public void FireProjectile(Vector3 direction)
    {
        rigidbody.velocity = direction * speed;
    }

    public void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= projectileDuration) ExpireSequence();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("Camera") || col.CompareTag("PlayerProjectile")) return;

        HittableBehaviour h = col.gameObject.GetComponent<HittableBehaviour>();
        if (h != null)
        {
            h.TakeDamage(damage);
            HitHittableSequence();
        }
        else
        {
            HitNonHittableSequence();
        }
    }

    void HitHittableSequence()
    {
        Destroy(gameObject);
    }

    void HitNonHittableSequence()
    {
        Destroy(gameObject);
    }

    void ExpireSequence()
    {
        Destroy(gameObject);
    }
}
