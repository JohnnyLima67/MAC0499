using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTester : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioSource mus;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 150, 30), "SFX"))
        {
            sfx.Play();
        }

        if (GUI.Button(new Rect(10, 170, 150, 30), "MUSIC"))
        {
            if (mus.isPlaying)
                mus.Stop();
            else
                mus.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
