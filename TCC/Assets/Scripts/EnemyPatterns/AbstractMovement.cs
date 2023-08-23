using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractMovement : MonoBehaviour
{
    [SerializeField] HealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        // Do nothing...
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.isDead())
            return;

        Move();
    }

    protected virtual void Move()
    {
        // Do nothing...
    }
}
