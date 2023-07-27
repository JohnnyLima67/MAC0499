using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Knight3 : MonoBehaviour
{
    private StateMachine fsm;
    [SerializeField] float detectionDistance = 20.0f;

    void Start()
    {
        fsm = new StateMachine(this);

        fsm.AddState("Idle", onLogic: (state) => Debug.Log("Estou no Idle"));
        fsm.AddState("Active", onLogic: (state) => Debug.Log("Estou no Active"));

        fsm.AddTwoWayTransition("Idle",
                                "Active",
                                t => DistanceToPlayer() < detectionDistance);

        fsm.SetStartState("Idle");
        fsm.Init();
    }

    float DistanceToPlayer()
    {
        Vector3 playerPos = GameManager.Instance.playerObject.transform.position;
        return Vector3.Distance(playerPos, transform.position);
    }

    void Update()
    {
        fsm.OnLogic();
    }
}
