using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.Tween;

public class GameplayManager : MonoBehaviour {

    // ------------------------ Variables ---------------------------
    public HeartProblem HeartProblem;

    [Header("Debug Informations")]
    public bool isGameplayStarted = false;

    [Header("Game Objects")]
    public GameObject DoorUI;
    public GameObject DiseaseBoxUI;
    public Text FadingText;
    public Text Timer;

    [Header("Gameplay Parameters")]
    public float TimerStartTime = 120;
    private float timerValue
    {
        get
        {
            return _timerValue;
        }
        set
        {
            Timer.text = value.ToString("0.00");
            _timerValue = value;
        }
    }
    private float _timerValue;

    public int NumberOfDoorsBeforeExit = 25;
    private int NumberOfDoorsPassed;

    public float DurationBetweenDoors = 4f;
    private AudioSource audioSource;
    private AudioClip normalHeartSound;
    private AudioClip SickHeartSound;
    private int NextDoorGoodnumber;

    [Header("MAZE")]
    public GameObject MazeObject;
    public Transform initialMazePos;
    public Transform ChoiceMazePos;

    public Image FadePanel;

    public static GameplayManager instance;
    // --------------------------------------------------------------

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    public void InitializeGame(HeartProblem problem)
    {
        DiseaseBoxUI.SetActive(true);
        HeartProblem = problem;

        DiseaseBoxUI.transform.Find("TextContainer/DiseaseName").GetComponent<Text>().text = HeartProblem.NameOfCondition;
        DiseaseBoxUI.transform.Find("ButtonContainer/FactsText").GetComponent<Text>().text = HeartProblem.QuickFacts;

        // Get sounds
        normalHeartSound = Resources.Load<AudioClip>("Sounds/Normal Heart");
        SickHeartSound = Resources.Load<AudioClip>("Sounds/"+ HeartProblem.AudioFileName);

        audioSource = GetComponent<AudioSource>();
        ListenToSound(SickHeartSound); // Play audio when the disease box is enabled

        timerValue = TimerStartTime;
    }

    public void StartGame()
    {
        DiseaseBoxUI.SetActive(false);
        StopListening(); // stop playing the audio when the disease box is closed

        isGameplayStarted = true;
        MoveMazeToChoice();
        StartCoroutine(GetToNextDoor());
    }

    public void Update()
    {
        if (isGameplayStarted)
        {
            if (timerValue > 0)
            {
                timerValue -= Time.deltaTime;
            }

            if (timerValue <= 0)
            {
                timerValue = 0;
                Loose();
            }
        } 
    }

    #region Fading Texts
    public void ShowText(bool win)
    {
        string text = "";
        int rng = Random.Range(0, 10);

        #region choose text
        if (win)
        {
            if (rng == 0)
                text = "Allright";
            if (rng == 1)
                text = "Awesome!";
            if (rng == 2)
                text = "Perfect! You remembered the sound!";
            if (rng == 3)
                text = "Great good focus!";
            if (rng == 4)
                text = "You are on fire today!";
            if (rng == 5)
                text = "Correct!";
            if (rng == 6)
                text = "Welldone!";
            if (rng == 7)
                text = "You’ve started to get the rhythm! Keep going!";
            if (rng == 8)
                text = "You are fire!";
            if (rng == 9)
                text = "You've started to get the rhythm! Go!";
        }
        else
        {
            if (rng == 0)
                text = "Focus on the sound and try again.";
            if (rng == 1)
                text = "Remember the sound you are following and try again.";
            if (rng == 2)
                text = "Listen once again.";
            if (rng == 3)
                text = "Listen to the sounds in silence of your mind.";
            if (rng == 4)
                text = "Pay attention to the sounds.";
            if (rng == 5)
                text = "Catch the sound and try again!";
            if (rng == 6)
                text = "You are improving! Try again!";
            if (rng == 7)
                text = "Don’t lose your focus!";
            if (rng == 8)
                text = "Keep up the good work. Give it another shot!";
            if (rng == 9)
                text = "Give it another go!";
        }
        #endregion

        #region Fade In & Out
        FadingText.text = text;
        FadingText.transform.gameObject.SetActive(true);
        TweenFactory.Tween("Color Fade In", 
            new Color(FadingText.color.r, FadingText.color.g, FadingText.color.b, 0), 
            new Color(FadingText.color.r, FadingText.color.g, FadingText.color.b, 1),
            DurationBetweenDoors / 2, TweenScaleFunctions.SineEaseInOut, (t) =>
            {
                // progress
                FadingText.color = t.CurrentValue;
            }, (t) =>
            {
                // completion

                TweenFactory.Tween("Color Fade Out",
                    new Color(FadingText.color.r, FadingText.color.g, FadingText.color.b, 1),
                    new Color(FadingText.color.r, FadingText.color.g, FadingText.color.b, 0),
                    DurationBetweenDoors / 2, TweenScaleFunctions.SineEaseInOut, (t2) =>
                    {
                        // progress
                        FadingText.color = t2.CurrentValue;
                    }, (t2) =>
                    {
                        // completion
                        Debug.Log("FadeIn -> Out done");
                    });
            });
        #endregion
    }

    #endregion

    #region DoorLogic
    public void ChooseDoor(int doorNb)
    {
        if (doorNb == NextDoorGoodnumber)
        {
            Debug.Log("<color=green>Good Door</color>");
            ShowText(true);

            NumberOfDoorsPassed++; // Progress
        }
        else
        {
            Debug.Log("<color=orange>Wrong Door</color>");
            ShowText(false);

            timerValue -= 10;
        }

        DoorUI.SetActive(false);
        FadeScreen(2f);
        StopListening(); // just in case
        Invoke("MoveMazeToChoice", 1);

        if (NumberOfDoorsPassed < NumberOfDoorsBeforeExit)
            StartCoroutine(GetToNextDoor());
        else
            Win();
    }

    IEnumerator GetToNextDoor()
    {
        Debug.Log("Going to next door");

        NextDoorGoodnumber = Random.Range(0, 2);

        yield return new WaitForSeconds(DurationBetweenDoors);
        DoorUI.SetActive(true);
    }
    #endregion

    #region Listening
    public void ListenToDoor(int doorNb)
    {
        Debug.Log("Listing to " + doorNb);
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        AudioClip clipToUse = normalHeartSound;

        if (doorNb == NextDoorGoodnumber)
        {
            clipToUse = SickHeartSound;
        }

        ListenToSound(clipToUse);
    }

    public void ListenToSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StopListening()
    {
        Debug.Log("Stop Listening");
        audioSource.Stop();
    }
    #endregion

    #region Win/Loose condition
    void Win()
    {
        Debug.LogWarning("WIN!");



    }

    void Loose()
    {
        Debug.LogWarning("LOOSE!");
    }
    #endregion

    #region Maze
    void MoveMazeToChoice()
    {
        TweenFactory.Tween("Maze", initialMazePos.position, ChoiceMazePos.position, DurationBetweenDoors, TweenScaleFunctions.SineEaseInOut, (t) =>
        {
            // Progress
            MazeObject.transform.position = t.CurrentValue;
        });
    }

    #endregion

    void FadeScreen(float time)
    {
        TweenFactory.Tween("ScreenFade", 0, 1, time/2f, TweenScaleFunctions.SineEaseInOut, (t2) =>
        {
            FadePanel.color = new Color(0, 0, 0, t2.CurrentValue);
        }, (t2) => {
            TweenFactory.Tween("ScreenFade", 1, 0, time / 2f, TweenScaleFunctions.SineEaseInOut, (t3) =>
            {
                FadePanel.color = new Color(0, 0, 0, t3.CurrentValue);
            });
        });
    }
}