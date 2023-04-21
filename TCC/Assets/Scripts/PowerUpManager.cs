using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private AbstractPowerUp powerUp;

    [SerializeField]
    private ManabarManager manabar;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (powerUp != null)
            {
                powerUp.Use();
                powerUp = null;
                // Debug.Log("Power Up usado!");
            }
            else
            {
                // Debug.Log("No Power Up!");
            }
        }
    }

    public void equipPowerUp(AbstractPowerUp aPowerUp)
    {
        powerUp = aPowerUp;
        // Debug.Log("Power Up equipado!");
    }
}
