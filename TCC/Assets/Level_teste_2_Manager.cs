using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_teste_2_Manager : MonoBehaviour
{

    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private int levelNumber;
    [SerializeField] private string sceneToGo;
    [SerializeField] private Collider2D c;
    // Start is called before the first frame update
    void Start()
    {
        c.enabled = false; 
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

    public void OnEnemyDied()
    {
        // Implement the logic you want to happen when an enemy dies and this GameObject is notified.
        Debug.Log("Received notification: Enemy with ID " + " died!");
        c.enabled = true; 

    }
}
