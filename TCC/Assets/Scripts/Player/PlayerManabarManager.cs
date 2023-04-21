using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManabarManager : MonoBehaviour
{
    [SerializeField] private Image manaBar;
    [SerializeField] private float maxMana = 200f;
    [SerializeField] private float mana = 200f;

    // Start is called before the first frame update
    void Start()
    {
        mana = Mathf.Clamp(mana, 0, maxMana);
        manaBar.fillAmount = mana / maxMana;
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Return))
    //     {
    //         LoseMana(20);
    //     }
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         GetMana(10);
    //     }
    // }

    public void LoseMana(float amount)
    {
        if (amount > 0)
        {
            mana = Mathf.Max(mana - amount, 0);
            manaBar.fillAmount = mana / maxMana;
        }
    }

    public void GetMana(float amount)
    {
        if (amount > 0)
        {
            mana = Mathf.Clamp(mana + amount, 0, maxMana);
            manaBar.fillAmount = mana / maxMana;
        }
    }

    public bool HasEnoughMana(float amount)
    {
        return (amount <= mana && amount >= 0);
    }
}
