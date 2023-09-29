using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float projectileDuration;
    [SerializeField] Vector3 velocity;
    [SerializeField] float hitRadius;
    [SerializeField] LayerMask hitMask;
    [SerializeField] LayerMask groundLayer;

    private float time = 0.0f;
    private Vector3 direction;
    private Vector3 lastPosition;

    public void FireProjectile(Vector3 direction)
    {
        this.direction = direction;
        lastPosition = GetCurrentPosition();
    }

    public void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= projectileDuration) ExpireSequence();

        // get difference between last position and next position
        Vector3 displacement = velocity * Time.fixedDeltaTime * Mathf.Sign(direction.x);

        transform.position += displacement;
        RaycastHit2D hit = Physics2D.Raycast(lastPosition,
                                             transform.position - lastPosition,
                                             displacement.magnitude,
                                             groundLayer);

        if (hit.collider != null)
        {
            HitNonHittableSequence();
        }

        lastPosition = GetCurrentPosition();

        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position,
                                                      hitRadius,
                                                      hitMask);

        if (col.Length > 0)
        {
			Debug.Log(col[0].name);
            FinalizeAttack(col);
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

    void FinalizeAttack(Collider2D[] col)
    {
        HittableBehaviour hittableBehaviour = col[0].GetComponent<HittableBehaviour>();
        HealthManager healthManager = col[0].GetComponent<HealthManager>();

        if (healthManager != null && healthManager.isDead()) return;
        if (hittableBehaviour == null || healthManager == null)
        {
            HitNonHittableSequence();
            return;
        }

        hittableBehaviour.TakeDamage(damage);
        HitHittableSequence();
    }

    Vector3 GetCurrentPosition()
    {
        return new Vector3(transform.position.x,
                           transform.position.y,
                           transform.position.z);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, hitRadius);
    }
}
