using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadCurrentScene() {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveLevel(int level)
    {
        int l = PlayerPrefs.GetInt("LevelsUnlocked", 1);
        if(l > level){
            return;
        }
        else {
            PlayerPrefs.SetInt("LevelsUnlocked", level + 1);
        }
    }
}
