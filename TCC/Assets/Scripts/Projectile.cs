using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float projectileDuration;

	public Vector3 velocity;
	public LayerMask hitMask = -1; // all layers by default


    float time = 0.0f;

    public void FireProjectile(Vector3 direction)
    {
        //rigidbody.velocity = direction * speed;
        return;
    }

    public void Update()
    {
        time += Time.deltaTime;

        if (time >= projectileDuration) ExpireSequence();

        		// get difference between last position and next position
		Vector3 displacement = velocity * Time.fixedDeltaTime;

		// get Raycast ray (cache last position)
		Ray2D ray = new Ray2D(transform.position, displacement);
		RaycastHit2D hit;

		// apply displacement
		transform.position += displacement;
        

		// raycast for any collisions since last position
        hit = Physics2D.Raycast(transform.position, displacement, 2, hitMask);
        Debug.DrawRay(transform.position, displacement);

		if (hit.collider != null)
		{
			// hit something!
			
			// example events
			Debug.Log(this.name + " has hit " + hit.collider.name + " at point " + hit.point);
			//hit.collider.SendMessage("OnProjectileCollision", this, SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
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

/*
public class Projectile : MonoBehaviour
{
	public Vector3 velocity;
	public LayerMask hitMask = -1; // all layers by default

	void FixedUpdate()
	{

		// get difference between last position and next position
		Vector3 displacement = velocity * Time.fixedDeltaTime;

		// get Raycast ray (cache last position)
		Ray ray = new Ray(transform.position, displacement);
		RaycastHit hit;

		// apply displacement
		transform.position += displacement;

		// raycast for any collisions since last position
		if (Physics.Raycast(ray, out hit, displacement.magnitude, hitMask))
		{
			// hit something!
			
			// example events
			Debug.Log(this.name + " has hit " + hit.collider.name + " at point " + hit.point);
			hit.collider.SendMessage("OnProjectileCollision", this, SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}
	}
}

*/