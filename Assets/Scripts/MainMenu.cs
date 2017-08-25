using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject MainMenuPanel;
	public GameObject LevelDifficultyPanel;
    public GameObject LevelSelectorPanel2;
	public GameObject LevelSelectorPanel1;

    public void Start()
    {
		MainMenuPanel.SetActive(true);
		LevelDifficultyPanel.SetActive (false);
		LevelSelectorPanel1.SetActive (false);
		LevelSelectorPanel2.SetActive(false);
    }

	public void SelectLevel1()
	{
		MainMenuPanel.SetActive(false);
		LevelDifficultyPanel.SetActive (false);
		LevelSelectorPanel1.SetActive (true);
		LevelSelectorPanel2.SetActive(false);
	}

    public void SelectLevel2()
    {
        MainMenuPanel.SetActive(false);
		LevelDifficultyPanel.SetActive (false);
		LevelSelectorPanel1.SetActive (false);
        LevelSelectorPanel2.SetActive(true);
    }

	public void DifficultyPanel()
	{
		MainMenuPanel.SetActive(false);
		LevelDifficultyPanel.SetActive (true);
		LevelSelectorPanel2.SetActive(false);
	}

    public void LoadTutorial()
    {
        MainMenuPanel.SetActive(false);
		LevelDifficultyPanel.SetActive (false);
		LevelSelectorPanel1.SetActive (false);
        LevelSelectorPanel2.SetActive(false);

        SceneManager.LoadScene("Tutorial", LoadSceneMode.Additive);
    }

    public void LoadAbout()
    {
		MainMenuPanel.SetActive(false);
		LevelDifficultyPanel.SetActive (false);
		LevelSelectorPanel1.SetActive (false);
		LevelSelectorPanel2.SetActive(false);

        SceneManager.LoadScene("About", LoadSceneMode.Additive);
    }

	public void PlayLevel1(int num)
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
			heartProblem = HeartSounds.MitralRegurgitation;
		}
		else if (num == 4)
		{
			heartProblem = HeartSounds.MidsystolicClick;
		}
		else if (num == 5)
		{
			heartProblem = HeartSounds.VentricularSeptalDefect;
		}
		else if (num == 6)
		{
			heartProblem = HeartSounds.AtrialSeptalDefect;
		}
		else if (num == 7)
		{
			heartProblem = HeartSounds.MitralStenosis;
		}
		else if (num == 8)
		{
			heartProblem = HeartSounds.AorticRegurgitation;
		}
		#endregion

		StartCoroutine(LoadOneSoundLevel(LevelDifficulty.Level1, heartProblem));
	}

    public void PlayLevel2(int num)
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
            heartProblem = HeartSounds.MitralRegurgitation;
        }
        else if (num == 4)
        {
            heartProblem = HeartSounds.MidsystolicClick;
        }
        else if (num == 5)
        {
            heartProblem = HeartSounds.VentricularSeptalDefect;
        }
        else if (num == 6)
        {
            heartProblem = HeartSounds.AtrialSeptalDefect;
        }
        else if (num == 7)
        {
            heartProblem = HeartSounds.MitralStenosis;
        }
        else if (num == 8)
        {
            heartProblem = HeartSounds.AorticRegurgitation;
        }
        #endregion

		StartCoroutine(LoadOneSoundLevel(LevelDifficulty.Level2, heartProblem));
    }

	public void PlayLevel3()
	{
		StartCoroutine (LoadOneSoundLevel (LevelDifficulty.Level3));
	}

	public void Back()
	{
		MainMenuPanel.SetActive(true);
		LevelDifficultyPanel.SetActive (false);
		LevelSelectorPanel1.SetActive (false);
		LevelSelectorPanel2.SetActive(false);
	}

	IEnumerator LoadOneSoundLevel(LevelDifficulty levelDifficulty, HeartProblem heartProblem = null)
    {
		LevelSelectorPanel1.SetActive (false);
        LevelSelectorPanel2.SetActive(false);
		LevelDifficultyPanel.SetActive (false);
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive);

        while (!sceneLoading.isDone)
        {
            yield return new WaitForEndOfFrame();
        }


        // Start game
		if (heartProblem != null)
        	Debug.Log("Starting Game for disease : " + heartProblem.formattedName);
        yield return new WaitForEndOfFrame();

        if (FindObjectOfType<GameplayManager>() != null)
        {
            GameplayManager.instance.InitializeGame(levelDifficulty, heartProblem);
        }
    }

    public void ReturnToMainMenu()
    {
        if(SceneManager.GetSceneAt(1) != null)
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
		LevelSelectorPanel1.SetActive (false);
        LevelSelectorPanel2.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}
