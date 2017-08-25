using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DigitalRuby.Tween;

public enum LevelDifficulty
{
	Level1,
	Level2,
	Level3
}

public class GameplayManager : MonoBehaviour
{

	// ------------------------ Variables ---------------------------
	public HeartProblem HeartProblem;

	[Header ("Debug Informations")]
	public bool isGameplayStarted = false;
	public bool isPaused = false;

	[Header ("Game Objects")]
	public GameObject DoorUI;
	public GameObject DiseaseBoxUI;
	public Text FinalTimeText;
	public Text FinalScoreText;
	public Text FinalMistakesText;
	public Text FadingText;
	public Text Timer;
	public Text BottomText;
	public GameObject EndPanel;
	public Text PauseButton;
	public Text InstructionText;

	[Header ("Gameplay Parameters")]
	LevelDifficulty _levelDifficulty;

	public LevelDifficulty levelDifficulty {
		get { return _levelDifficulty; }
	}

	public float TimerStartTime = 120;

	private float timerValue {
		get {
			return _timerValue;
		}
		set {
			Timer.text = value.ToString ("0.00");
			_timerValue = value;
		}
	}

	private float _timerValue;
	public bool _timerOn = false;
	public int NumberOfDoorsBeforeExit = 10;
	private int NumberOfDoorsPassed;

	public float DurationBetweenDoors = 4f;
	private AudioSource _audioSource;
	private Heart _wrongHeart;
	private Heart _correctHeart;
	private HeartProblem _heartProblem;
	private int NextDoorGoodnumber;

	private int _mistakes = 0;

	[Header ("MAZE")]
	public GameObject MazeObject;
	public Transform initialMazePos;
	public Transform ChoiceMazePos;

	public Image FadePanel;

	private Coroutine co;
	private int Soundnum = 0;

	public static GameplayManager instance;
	// --------------------------------------------------------------

	private void Awake ()
	{
		if (instance != null)
			Destroy (this.gameObject);
		else
			instance = this;
	}

	public void InitializeGame (LevelDifficulty levelDifficulty, HeartProblem problem)
	{
		_audioSource = GetComponent<AudioSource> ();
		_heartProblem = problem;
		_levelDifficulty = levelDifficulty;

		if (levelDifficulty == LevelDifficulty.Level1)
			ShowDiseaseInformations (problem);
		else
			StartGame ();

		BottomText.text = NumberOfDoorsPassed + " / " + NumberOfDoorsBeforeExit;
		timerValue = TimerStartTime;
	}

	public void StartGame ()
	{
		DiseaseBoxUI.SetActive (false);
		StopListening (); // stop playing the audio when the disease box is closed

		isGameplayStarted = true;
		isPaused = false;
		PauseButton.text = "II";
		Time.timeScale = 1;
		_timerOn = true;
		MoveMazeToChoice ();
		InstructionText.color = new Color (InstructionText.color.r, InstructionText.color.g, InstructionText.color.g, 1.0f);
		StartCoroutine (GetToNextDoor ());
	}

	public void PauseGame ()
	{
		if (isPaused) {
			FadePanel.color = new Color (0, 0, 0, 0);

			PauseButton.text = "II";
			Time.timeScale = 1;
			isPaused = false;
		} else {
			FadePanel.color = new Color (0, 0, 0, 1);

			PauseButton.text = "►";
			Time.timeScale = 0;
			isPaused = true;
		}
	}

	void ShowDiseaseInformations (HeartProblem problem)
	{
		HeartProblem = problem;

		DiseaseBoxUI.transform.Find ("TextContainer/DiseaseName").GetComponent<Text> ().text = HeartProblem.formattedName;

		DiseaseBoxUI.transform.Find ("ButtonContainer/FactsText_01").GetComponent<Text> ().text = HeartProblem.quickFacts01;
		DiseaseBoxUI.transform.Find ("ButtonContainer/FactsText_02").GetComponent<Text> ().text = HeartProblem.quickFacts02;
		DiseaseBoxUI.transform.Find ("ButtonContainer/FactsText_03").GetComponent<Text> ().text = HeartProblem.quickFacts03;

		DiseaseBoxUI.SetActive (true);
		NextSounds ();
	}

	public void NextSounds ()
	{
		Soundnum++;
		if (Soundnum == 1) {
			_audioSource.volume = 0.5f; // Vincent voice is really loud

			if (co != null)
				StopCoroutine (co);

			_audioSource.Stop ();
			co = StartCoroutine (playDiseaseVoiceExplanation (HeartProblem.slide01Sounds));
		} else if (Soundnum == 2) {
			if (co != null)
				StopCoroutine (co);

			_audioSource.Stop ();
			co = StartCoroutine (playDiseaseVoiceExplanation (HeartProblem.slide02Sounds));
		} else if (Soundnum == 3) {
			if (co != null)
				StopCoroutine (co);

			_audioSource.Stop ();
			co = StartCoroutine (playDiseaseVoiceExplanation (HeartProblem.slide03Sounds));
		} else if (Soundnum == 4) {
			if (co != null)
				StopCoroutine (co);

			_audioSource.volume = 1;

			DiseaseBoxUI.SetActive (true);
			DiseaseBoxUI.transform.Find ("ButtonContainer").Find ("FactsText_03").GetComponent<Text> ().text = "Listen closely to the sound";
			ListenToSound (HeartProblem.audioClip); // Play audio when the disease box is enabled
		} else if (Soundnum == 5) {
			_audioSource.volume = 1;
			HideDiseaseInformationsAndMoveon ();
		}
	}

	IEnumerator playDiseaseVoiceExplanation (AudioClip[] clips)
	{
		for (int i = 0; i < clips.Length; i++) {
			_audioSource.PlayOneShot (clips [i]);
			yield return new WaitForSeconds (clips [i].length + 0.25f);
		}

		yield return null;
	}

	public void HideDiseaseInformationsAndMoveon ()
	{
		StartGame ();
	}

	public void Update ()
	{
		if (isGameplayStarted) {
			if (timerValue > 0 && _timerOn) {
				timerValue -= Time.deltaTime;
			}

			if (timerValue <= 0) {
				timerValue = 0;
				Lose ();
			}
		}
	}

	#region Fading Texts

	public void ShowText (bool win)
	{
		string text = "";
		string[] winTexts = {
			"Alright!",
			"Awesome!",
			"Perfect! You remembered the sound!",
			"Great! Good focus!",
			"You are on fire today!",
			"Correct!",
			"Well done!",
			"You've started to get the rhythm! Keep going!",
			"You are on fire!",
			"You've started to get the rhythm! Go!",
		};
		string[] loseTexts = {
			"Focus on the sound and try again.",
			"Remember the sound you are following and try again.",
			"Listen once again.",
			"Listen to the sounds in silence of your mind.",
			"Pay attention to the sounds.",
			"Catch the sound and try again!",
			"Try again!",
			"Don't lose focus!",
			"Wrong answer. Give it another shot!",
			"Give it another go!",
		};

		if (win)
			text = winTexts [Random.Range (0, winTexts.Length)];
		else
			text = loseTexts [Random.Range (0, loseTexts.Length)];

		#region Fade In & Out
		FadingText.text = text;
		FadingText.transform.gameObject.SetActive (true);
		TweenFactory.Tween ("Color Fade In", 
			new Color (FadingText.color.r, FadingText.color.g, FadingText.color.b, 0), 
			new Color (FadingText.color.r, FadingText.color.g, FadingText.color.b, 1),
			DurationBetweenDoors / 2, TweenScaleFunctions.SineEaseInOut, (t) => {
			// progress
			FadingText.color = t.CurrentValue;
		}, (t) => {
			// completion

			TweenFactory.Tween ("Color Fade Out",
				new Color (FadingText.color.r, FadingText.color.g, FadingText.color.b, 1),
				new Color (FadingText.color.r, FadingText.color.g, FadingText.color.b, 0),
				DurationBetweenDoors / 4, TweenScaleFunctions.SineEaseInOut, (t2) => {
				// progress
				FadingText.color = t2.CurrentValue;
			}, (t2) => {
				// completion
				TweenFactory.Tween ("Color Fade In", 
					new Color (InstructionText.color.r, InstructionText.color.g, InstructionText.color.b, 0), 
					new Color (InstructionText.color.r, InstructionText.color.g, InstructionText.color.b, 1),
					DurationBetweenDoors, TweenScaleFunctions.SineEaseInOut, (t3) => {
					// progress
					InstructionText.color = t.CurrentValue;
				});
			});
		});
		#endregion
	}

	#endregion

	#region DoorLogic

	void SetHeartSounds ()
	{
		switch (_levelDifficulty) {
		case LevelDifficulty.Level1:
			_correctHeart = _heartProblem;
			_wrongHeart = HeartSounds.NormalHeart;
			break;
		case LevelDifficulty.Level2:
			_correctHeart = _heartProblem;
			_wrongHeart = HeartSounds.GetRandomHeartProblem (_correctHeart);
			break;
		case LevelDifficulty.Level3:
			_wrongHeart = HeartSounds.GetRandomHeartProblem ();
			_correctHeart = HeartSounds.GetRandomHeartProblem (_wrongHeart);
			break;
		}
	}

	public void ChooseDoor (int doorNb)
	{
		InstructionText.color = new Color (InstructionText.color.r, InstructionText.color.g, InstructionText.color.b, 0.0f);
		if (doorNb == NextDoorGoodnumber) {
			Debug.Log ("<color=green>Good Door</color>");
			ShowText (true);

			NumberOfDoorsPassed++; // Progress

			BottomText.text = NumberOfDoorsPassed + " / " + NumberOfDoorsBeforeExit;
		} else {
			Debug.Log ("<color=orange>Wrong Door</color>");
			ShowText (false);

			timerValue -= 10;
			_mistakes++;
		}

		DoorUI.SetActive (false);
		FadeScreen (2f);
		StopListening (); // just in case
		Invoke ("MoveMazeToChoice", 1);

		if (NumberOfDoorsPassed < NumberOfDoorsBeforeExit)
			StartCoroutine (GetToNextDoor ());
		else
			Win ();
	}

	IEnumerator GetToNextDoor ()
	{
		SetHeartSounds ();
		_timerOn = false;
		Debug.Log ("Going to next door");

		InstructionText.text = "Follow the <i>";
		InstructionText.text += _correctHeart.name + " ";
		InstructionText.text += "</i> sound to find the exit.";

		NextDoorGoodnumber = Random.Range (0, 2);

		yield return new WaitForSeconds (DurationBetweenDoors);
		DoorUI.SetActive (true);
		_timerOn = true;
	}

	#endregion

	#region Listening

	public void ListenToDoor (int doorNb)
	{
		Debug.Log ("Listing to " + doorNb);

		AudioClip clipToUse = _wrongHeart.audioClip;

		if (doorNb == NextDoorGoodnumber) {
			clipToUse = _correctHeart.audioClip;
		}

		if (_audioSource.isPlaying) {
			if (_audioSource.clip != clipToUse) {
				_audioSource.Stop ();
				ListenToSound (clipToUse);
			}
		} else {
			ListenToSound (clipToUse);
		}
	}

	public void ListenToSound (AudioClip clip)
	{
		_audioSource.clip = clip;
		_audioSource.Play ();
	}

	public void StopListening ()
	{
		Debug.Log ("Stop Listening");
		_audioSource.Stop ();
	}

	#endregion

	#region Win/Loose condition

	void Win ()
	{
		isGameplayStarted = false;
		Debug.LogWarning ("WIN!");
		DoorUI.SetActive (false);
		StopAllCoroutines ();
		FadeToWhite (2);
		Time.timeScale = 0;

		EndPanel.transform.Find ("TextContainer").Find ("Text").GetComponent<Text> ().text = _mistakes > 0 ? "Y o u  w i n !" : "P e r f e c t !";
		FinalTimeText.text = "Time : " + Timer.text;
		FinalScoreText.text = "Score : " + BottomText.text;
		FinalMistakesText.text = "Errors : " + (_mistakes > 0 ? "<color=red>" : "") + _mistakes.ToString () + (_mistakes > 0 ? "</color>" : "");


		EndPanel.SetActive (true);
	}

	void Lose ()
	{
		Time.timeScale = 0;
		isGameplayStarted = false;
		Debug.LogWarning ("LOOSE!");
		DoorUI.SetActive (false);
		StopAllCoroutines ();
		FadeToWhite (2);

		EndPanel.transform.Find ("TextContainer").Find ("Text").GetComponent<Text> ().text = "T r y  A g a i n !";
		FinalTimeText.text = "Time : " + Timer.text;
		FinalScoreText.text = "Score : " + BottomText.text;
		FinalMistakesText.text = "Errors : " + (_mistakes > 0 ? "<color=red>" : "") + _mistakes.ToString () + (_mistakes > 0 ? "</color>" : "");

		EndPanel.SetActive (true);
	}

	#endregion

	#region Maze

	void MoveMazeToChoice ()
	{
		TweenFactory.Tween ("Maze", initialMazePos.position, ChoiceMazePos.position, DurationBetweenDoors, TweenScaleFunctions.SineEaseInOut, (t) => {
			// Progress
			MazeObject.transform.position = t.CurrentValue;
		});
	}

	#endregion

	void FadeScreen (float time)
	{
		TweenFactory.Tween ("ScreenFade", 0, 1, time / 2f, TweenScaleFunctions.SineEaseInOut, (t2) => {
			FadePanel.color = new Color (0, 0, 0, t2.CurrentValue);
		}, (t2) => {
			TweenFactory.Tween ("ScreenFadeALpha", 1, 0, time / 2f, TweenScaleFunctions.SineEaseInOut, (t3) => {
				FadePanel.color = new Color (0, 0, 0, t3.CurrentValue);
			});
		});
	}

	void FadeToWhite (float time)
	{
		FadePanel.color = new Color (1, 1, 1, 0);
		FadePanel.gameObject.SetActive (true);

		TweenFactory.Tween ("ScreenFadeWhite", 0, 1, time / 2f, TweenScaleFunctions.SineEaseInOut, (t2) => {
			FadePanel.color = new Color (1, 1, 1, t2.CurrentValue);
		});
	}

	public void BackToMainMenu ()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
