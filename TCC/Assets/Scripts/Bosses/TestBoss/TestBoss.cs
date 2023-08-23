using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;
using FSM;

public class TestBoss : MonoBehaviour
{
    public bool enteredBossRoom = false;
    [SerializeField] Transform visionObject;
    [SerializeField] LayerMask playerAndGroundLayer;
    [SerializeField] BehaviorTree battleBehaviourTree;
    [SerializeField] BehaviorTree idleBehaviourTree;
    [SerializeField] HealthManager healthManager;
    [SerializeField] float distanceF;
    [SerializeField] float distanceB;

    private float phase = 1;

    private StateMachine fsm;

    void DefineBattleBT()
    {
        battleBehaviourTree = new BehaviorTreeBuilder(gameObject)
            .Sequence()
                .RepeatUntilSuccess()
                    .Selector()
                        .Sequence()
                            .Condition(() => {return SawOrHeardPlayer();})
                            .Do(() => { return TaskStatus.Success; })
                        .End()
                        .Sequence()
                            .Condition(() => {return !SawOrHeardPlayer();})
                            .Flip()
                        .End()                            
                    .End()
                .End()

                .SelectorRandom()
                    .Sequence()
                        .TriggerAnimation("WalkForward")
                        .WalkForward(3.5f, 5)
                    .End()
                    .Sequence()
                        .TriggerAnimation("WalkBackward")
                        .WalkBackward(3.5f, 5)
                    .End()
                    .Sequence()
                        .TriggerAnimation("StandingAttack")
                        .WaitTime(1.0f)
                    .End()
                    .Sequence()
                        .TriggerAnimation("RunningAttack")
                        .WalkForward(7, 7)
                    .End()
                .End()
            .End()
            .Build();
    }

    void DefineIdleBT()
    {
        idleBehaviourTree = new BehaviorTreeBuilder(gameObject)
            .Sequence()
            .Do(() => {return TaskStatus.Continue;})
            .End().Build();
    }

    void Awake()
    {
        DefineBattleBT();
        DefineIdleBT();
        fsm = new StateMachine(this);
        fsm.AddState("Idle",
                      onLogic: (state) => idleBehaviourTree.Tick(),
                      onExit: (state) => idleBehaviourTree.Reset());

        fsm.AddState("Battle",
                     onLogic: (state) => battleBehaviourTree.Tick(),
                     onExit: (state) => battleBehaviourTree.Tick());

        fsm.AddTransition("Idle", "Battle", t => enteredBossRoom);
        fsm.Init();
    }

    // Update is called once per frame
    void Update()
    {
        // if (healthManager.CurrentHealth() < 100 && phase == 1)
        // {
        //     phase = 2;
        //     battleBehaviourTree.Reset();
        //     Debug.Log("Mudando pra fase 2");
        // }
        fsm.OnLogic();
    }

    bool SawOrHeardPlayer()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position,
                                             Vector3.Normalize(visionObject.transform.position - transform.position),
                                             20,
                                             playerAndGroundLayer);
        
        Debug.DrawRay(transform.position, 
                      Vector3.Normalize(visionObject.transform.position - transform.position),
                      Color.red);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject);
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("vi player");
                return true;
            }
        }

        return false;
    }

}
