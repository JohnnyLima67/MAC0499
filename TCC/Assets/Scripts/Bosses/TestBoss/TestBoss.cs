using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;

public class TestBoss : MonoBehaviour
{
    [SerializeField] BehaviorTree bt;
    [SerializeField] HealthManager healthManager;
    [SerializeField] float distanceF;
    [SerializeField] float distanceB;
    private float phase = 1;

    void Awake()
    {
        bt = new BehaviorTreeBuilder(gameObject)
            .Selector()
                .Sequence() // Fase 1
                    .Condition(() => {return (healthManager.CurrentHealth() >= 100);})
                    .WalkForward(d: distanceF)
                    .WalkBackward(d: distanceB)
                    .RepeatForever()
                        .SelectorRandom()
                            .Do(() => {Debug.Log("Ataque 1"); return TaskStatus.Success;})
                            .Do(() => {Debug.Log("Ataque 2"); return TaskStatus.Success;})
                            .Do(() => {Debug.Log("Ataque 3"); return TaskStatus.Success;})
                        .End()
                    .End()
                .End()
                .Sequence() // Fase 2
                    .Do(() => {Debug.Log("Estou na fase 2"); return TaskStatus.Success;})
                    .WalkBackward(d: 3.0f)
                .End()
            .End()
            .Build();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.CurrentHealth() < 100 && phase == 1)
        {
            phase = 2;
            bt.Reset();
            Debug.Log("Mudando pra fase 2");
        }
        bt.Tick();
    }
}
