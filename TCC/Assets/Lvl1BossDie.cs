using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1BossDie : BossDieTrigger
{
    [SerializeField] private LevelEnder _lvlender;

    public override void OnDieTrigger()
    {
        _lvlender.EndLevel();
    }
}
