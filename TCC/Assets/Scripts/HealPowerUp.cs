using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : AbstractPowerUp
{
    private PlayerHealthbarManager playerHealthManager;

    public void Awake()
    {
        manaCost = 20;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 0)
            playerHealthManager = players[0].GetComponent<PlayerHealthbarManager>();
    }

    public override void Use()
    {
        playerHealthManager.Heal(100.0f);
    }
}
