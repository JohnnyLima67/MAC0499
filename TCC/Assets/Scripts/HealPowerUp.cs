using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : AbstractPowerUp
{
    private PlayerHealthbarManager playerHealthManager;
    [SerializeField] private float healthRegen;
    public void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 0)
            playerHealthManager = players[0].GetComponent<PlayerHealthbarManager>();
    }

    public override void Use()
    {
        playerHealthManager.Heal(healthRegen);
    }
}
