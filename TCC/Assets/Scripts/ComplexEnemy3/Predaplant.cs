using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using UnityEditor;

public class Predaplant : MonoBehaviour
{
    private StateMachine fsm;

    private Transform playerTransform;

    public bool finishedAttackAnimation = false;

    [SerializeField] bool drawVisionGizmos = false;
    [SerializeField] bool drawAttackRadius = false;

    [SerializeField] Transform visionOrigin;
    [SerializeField] Transform attackOrigin;

    [SerializeField] EnemyAnimator animator;
    [SerializeField] Enemy thisEnemy;

    [SerializeField] LayerMask playerLayer;

    [SerializeField] float visionRadius;
    [SerializeField] float attackRadius;

    [SerializeField] PlayerDirection playerDir;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        fsm = new StateMachine(this);

        fsm.AddState("Idle");
        fsm.AddState("Active");
        fsm.AddState("Attacking",
            onEnter: (state) => { animator.unityAnimator.SetTrigger("Attack"); } );
        fsm.AddState("Flip",
            onEnter: (state) => thisEnemy.Flip());

        fsm.AddTransition("Idle", "Active", t => SawOrHeardPlayer());
        fsm.AddTransition("Active", "Attacking", t => IsPlayerClose());
        fsm.AddTransition("Active", "Flip", t => IsPlayerBehind());
        fsm.AddTransition("Attacking", "Active", t => IsAttackingFinished());
        fsm.AddTransition("Flip", "Active", t => true);

        fsm.Init();
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnLogic();
    }

    bool SawOrHeardPlayer()
    {
        Collider2D col = Physics2D.OverlapCircle(visionOrigin.position, visionRadius, playerLayer);

        return col != null;
    }

    bool IsPlayerClose()
    {
        if (playerTransform != null)
        {
            return (playerTransform.position - attackOrigin.position).magnitude < attackRadius;
        }
        return false; 
    }

    bool IsPlayerBehind()
    {
        return playerDir.IsPlayerBack(playerTransform);
    }

    bool IsAttackingFinished()
    {
        if (finishedAttackAnimation)
        {
            finishedAttackAnimation = false;
            return true;
        }
        return false;
    }

    public void EndOfAttackAnimation()
    {
        finishedAttackAnimation = true;
    }

    void OnDrawGizmos()
    {
        if (visionOrigin != null && drawVisionGizmos)
        {
            Handles.color = Color.white;
            Handles.DrawWireDisc(visionOrigin.position, new Vector3(0, 0, 1), visionRadius, 0.1f);
        }

        if (drawAttackRadius)
        {
            Handles.color = Color.red;
            Handles.DrawWireDisc(attackOrigin.position, new Vector3(0, 0, 1), attackRadius, 0.1f);
        }
            
    }
}
