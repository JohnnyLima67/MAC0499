using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_teste_1_Manager : MonoBehaviour
{

    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private int levelNumber;
    [SerializeField] private string sceneToGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Colidi" + col.collider.gameObject.name);
        if (col.collider.gameObject.tag == "Player") {
            sceneLoader.SaveLevel(levelNumber);
            sceneLoader.LoadScene(sceneToGo);
        }
        else {
            return;
        }
    }
}
