using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponColliderDetector : MonoBehaviour
{
    public List<Collider2D> enemiesInWeaponRange;
    [SerializeField] string[] hittableTags;

    void Awake()
    {
        enemiesInWeaponRange = new List<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        foreach(string t in hittableTags)
        {
            if (col.gameObject.CompareTag(t))
            {
                enemiesInWeaponRange.Add(col);
            }
        }
    }

	void OnTriggerStay2D(Collider2D col)
	{
		foreach(string t in hittableTags)
        {
            if (col.gameObject.CompareTag(t) && !enemiesInWeaponRange.Contains(col))
            {
                enemiesInWeaponRange.Add(col);
            }
        }
	}
}
