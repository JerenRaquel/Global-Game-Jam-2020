using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    #region instance
    public static SceneController instance = null;
    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this);
    }
    #endregion

    int currentScene = 0;
    // Start is called before the first frame update
    void Start()
    {
        LoadScene(1);
    }

    //unloads all scene other than the scene manager scene and loads a new scene besides it
    //pass the index of the scene to load that scene
    public void LoadScene(int sceneIndex)
    {
        // if(SceneManager.sceneCount > 1)
        // {
        //     for (int i = 1; i < SceneManager.sceneCount; i++)
        //     {
        //         SceneManager.UnloadSceneAsync(i);
        //     }
        // }
        if(currentScene != 0)
            SceneManager.UnloadSceneAsync(currentScene);
        currentScene = sceneIndex;

        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
    }
}
