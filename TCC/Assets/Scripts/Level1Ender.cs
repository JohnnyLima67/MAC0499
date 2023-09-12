using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Ender : LevelEnder
{

    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private int levelNumber;
    [SerializeField] private string sceneToGo;
    // Start is called before the first frame update

    public override void EndLevel() {
            sceneLoader.SaveLevel(levelNumber);
            sceneLoader.LoadScene(sceneToGo);

    }
}
