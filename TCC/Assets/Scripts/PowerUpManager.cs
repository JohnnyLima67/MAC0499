using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;
public class PowerUpManager : MonoBehaviour
{
    private AbstractPowerUp powerUp;
    private InputManager _input;
    private FrameInput FrameInput;

    [SerializeField]
    private PlayerManabarManager manabar;
   
    protected virtual void Awake() {
        _input = GetComponent<InputManager>();

    }
    // Update is called once per frame
    void Update()
    {
        FrameInput = _input.FrameInput;
        if (FrameInput.PowerUp)
        {
            Debug.Log("Foi");
            if (powerUp != null && manabar.HasEnoughMana(powerUp.manaCost))
            {
                Debug.Log("Foi");
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
        Debug.Log("Power Up equipado!");
    }
}
