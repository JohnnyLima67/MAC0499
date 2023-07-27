using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Knight3 : MonoBehaviour
{
    private StateMachine fsm;
    private Transform lastPlayerPos = null;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Enemy thisEnemy;
    [SerializeField] Transform visionObject;
    [SerializeField] float detectionDistance = 20.0f;
    [SerializeField] float speed = 2.0f;
    [SerializeField] LayerMask playerAndGroundLayer;

    void Start()
    {
        fsm = new StateMachine(this);

        fsm.AddState("Idle");
        fsm.AddState("Active",
                     onEnter: (state) => Debug.Log("Estou no Active"),
                     onLogic: (state) => FollowPlayer());
        fsm.AddState("Flip", onEnter: (state) => thisEnemy.Flip());

        fsm.AddTransition("Idle",
                          "Active",
                          t => SawOrHeardPlayer());

        fsm.AddTransition("Active", "Flip", t => IsInPlayerLastPos());
        fsm.AddTransition("Flip", "Idle", t => true);

        fsm.SetStartState("Idle");
        fsm.Init();
    }

    bool IsInPlayerLastPos()
    {
        if (Mathf.Abs(transform.position.x - lastPlayerPos.position.x) < 0.5) return true;
        else return false;
    }

    bool SawOrHeardPlayer()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position,
                                             Vector3.Normalize(visionObject.transform.position - transform.position),
                                             playerAndGroundLayer);
        Debug.DrawRay(transform.position,
                      Vector3.Normalize(visionObject.transform.position - transform.position), Color.red);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject);
            if (hit.collider.CompareTag("Player"))
            {
                lastPlayerPos = hit.collider.gameObject.transform;
                return true;
            }
        }

        lastPlayerPos = null;
        return false;
    }

    void FollowPlayer()
    {
        Vector3 direction = Vector3.Normalize(lastPlayerPos.transform.position - transform.position);
        Vector3 s = direction * speed;
        s.y = rb.velocity.y;

        rb.velocity = s;
    }

    float Step()
    {
        return speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        fsm.OnLogic();
    }

    // void OnDrawGizmos()
    // {
    //     if(transform.position != null && visionObject != null)
    //      {
    //          // Draws a blue line from this transform to the target
    //          Gizmos.color = Color.magenta;
    //          Gizmos.DrawLine(transform.position, visionObject.transform.position);
    //      }
    // }
}
