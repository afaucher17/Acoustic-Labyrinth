using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DigitalRuby.Tween;

public class LoadingScreen : MonoBehaviour {

    public Image BlackImage;
    public GameObject[] Slides;

    public int fadeTime = 4;

    void Start ()
    {
        for (int i = 0; i < Slides.Length; i++)
        {
            if (i == 0)
                Slides[0].SetActive(true);
            else
                Slides[i].SetActive(false);
        }

        BlackImage.gameObject.SetActive(true);

        StartCoroutine(ShowAllSlides());
    }

    IEnumerator ShowAllSlides()
    {
        for (int i = 0; i < Slides.Length; i++)
        {
            if(i > 0)
            {
                Slides[i - 1].SetActive(false);
                Slides[i].SetActive(true);
            }

            FadeInOut(fadeTime);
            yield return new WaitForSeconds(fadeTime);
        }

        float waiter = 1;
        while (waiter > 0)
        {
            waiter -= Time.deltaTime;
            GetComponent<AudioSource>().volume = waiter;

            yield return new WaitForEndOfFrame();
        }

        LoadMainMenu();

        yield return new WaitForEndOfFrame();
    }

    void FadeInOut(float time)
    {
        TweenFactory.Tween("Color Fade In", new Color(0, 0, 0, 1), new Color(0, 0, 0, 0), time / 2, TweenScaleFunctions.CubicEaseInOut, (t) =>
        {
            BlackImage.color = t.CurrentValue;
        }, (t) =>
        {
            TweenFactory.Tween("Color Fade Out", new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), time / 2, TweenScaleFunctions.CubicEaseInOut, (t2) =>
            {
                BlackImage.color = t2.CurrentValue;
            });
        });
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}