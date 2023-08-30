using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractMovement : MonoBehaviour
{
    [SerializeField] public HealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        // Do nothing...
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.isDead())
            NotMove();
        else 
            Move();
    }

    protected virtual void Move()
    {
        // Do nothing...
    }

    protected virtual void NotMove()
    {
        // Faça algo...
    }
}
