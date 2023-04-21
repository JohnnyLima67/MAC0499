using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private AbstractPowerUp powerUp;

    [SerializeField]
    private PlayerManabarManager manabar;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (powerUp != null && manabar.HasEnoughMana(powerUp.manaCost))
            {
                powerUp.Use();
                manabar.LoseMana(powerUp.manaCost);
            }
            else
            {
            }
        }
    }

    public void equipPowerUp(AbstractPowerUp aPowerUp)
    {
        powerUp = aPowerUp;
        // Debug.Log("Power Up equipado!");
    }
}
