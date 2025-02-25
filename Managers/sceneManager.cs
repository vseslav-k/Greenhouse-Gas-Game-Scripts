using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    [SerializeField] string mainMenue;
    [SerializeField] string gameScene;

    public void loadGameScene()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene(gameScene);
    }

    public void loadMainMenuScene()
    {

        ScoreManager.score = 0;
        SceneManager.LoadScene(mainMenue);
    }
}
