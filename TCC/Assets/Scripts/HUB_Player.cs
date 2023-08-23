using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUB_Player : MonoBehaviour
{
    private float velocity = 15.0f;
    private bool input_locked = true;
    public int Levels;
    [SerializeField]
    private HUBPosition currentHubPosition;

    // Start is called before the first frame update
    void Start()
    {
        int nLevels = PlayerPrefs.GetInt("LevelsUnlocked", 1);
        Levels = nLevels;
        Debug.Log(nLevels);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(input_locked);
        if (!input_locked)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && currentHubPosition.next != null && Levels > currentHubPosition.level)
            {
                input_locked = true;
                currentHubPosition = currentHubPosition.next;
                Debug.Log("Entrei");
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && currentHubPosition.prev != null)
            {
                input_locked = true;
                currentHubPosition = currentHubPosition.prev;
            }
        }
        else
        {
            WalkToPosition();
        }

        if (!input_locked && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(currentHubPosition.sceneName);
        }
    }

    void WalkToPosition()
    {
        Vector3 from = transform.position;
        Vector3 to = currentHubPosition.transform.position;
        Vector3 walkDirection = (to - from).normalized;

        if (velocity * Time.deltaTime < (to - from).magnitude)
            transform.Translate(walkDirection * velocity * Time.deltaTime);
        else
        {
            transform.Translate(to - from);
            input_locked = false;
        }
    }
}
