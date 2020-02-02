using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    public GameObject creditsUI;
    public GameObject tutorialUI;

    public void StartNewGame()
    {
        SceneController.instance.LoadScene(2);
    }

    public void Tutorial()
    {
        tutorialUI.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialUI.SetActive(false);
    }

    public void Credits()
    {
        creditsUI.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsUI.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
