using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBossTrigger : MonoBehaviour
{

    [SerializeField] private GameObject[] room;

    void OnTriggerEnter2D(Collider2D col)
    {
        for(int i = 0; i < room.Length; i++) {
            if(room[i] != null)
                room[i].SetActive(true);
        }
    }}
