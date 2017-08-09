using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject MainMenuPanel;
    public GameObject LevelSelectorPanel;

    public void Start()
    {
        MainMenuPanel.SetActive(true);
    }

    public void SelectLevel()
    {
        MainMenuPanel.SetActive(false);
        LevelSelectorPanel.SetActive(true);
    }

    public void LoadTutorial()
    {
        MainMenuPanel.SetActive(false);
        LevelSelectorPanel.SetActive(false);

        SceneManager.LoadScene("Tutorial", LoadSceneMode.Additive);
    }

    public void PlayLevel(int num)
    {
        #region Get HeartProblem
        HeartProblem heartProblem = new HeartProblem();
        if (num == 0)
        {
            heartProblem = HeartSounds.ThirdHeart;
        }
        else if (num == 1)
        {
            heartProblem = HeartSounds.FourthHearth;
        }
        else if (num == 2)
        {
            heartProblem = HeartSounds.AorticStenosis;
        }
        else if (num == 3)
        {

        }
        else if (num == 4)
        {

        }
        else if (num == 5)
        {

        }
        else if (num == 6)
        {

        }
        else if (num == 7)
        {

        }
        else if (num == 8)
        {

        }
        #endregion

        StartCoroutine(LoadOneSoundLevel(heartProblem));
    }

    public void PlayHardLevel()
    {

    }

    IEnumerator LoadOneSoundLevel(HeartProblem heartProblem)
    {
        LevelSelectorPanel.SetActive(false);
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive);

        while (!sceneLoading.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        // Start game
        Debug.Log("Starting Game for disease : " + heartProblem.NameOfCondition);
        yield return new WaitForEndOfFrame();

        if (FindObjectOfType<GameplayManager>() != null)
        {
            GameplayManager.instance.InitializeGame(heartProblem);
        }
    }

    public void ReturnToMainMenu()
    {
        if(SceneManager.GetSceneAt(1) != null)
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));

        LevelSelectorPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}
