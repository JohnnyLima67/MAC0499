using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedWeaponBehaviour : MonoBehaviour
{
    public GameObject directionSetter;

    [SerializeField] GameObject projectile;

    public void Fire()
    {
        GameObject instance = Instantiate(projectile,
                                          directionSetter.transform.position,
                                          directionSetter.transform.rotation);
        instance.GetComponent<Projectile>().FireProjectile(directionSetter.transform.right);
    }

    public void TriggerFireAnimation()
    {

    }
}
