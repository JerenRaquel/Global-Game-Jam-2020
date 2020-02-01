using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadScene(1);
    }

    void LoadScene(int sceneIndex)
    {
        for (int i = 1; i < SceneManager.sceneCount; i++)
        {
            SceneManager.UnloadSceneAsync(i);
        }
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
    }
}
