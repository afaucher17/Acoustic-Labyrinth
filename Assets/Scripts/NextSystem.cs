using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextSystem : MonoBehaviour
{
    private int slideNb = 0;
    public GameObject[] Slides;
    public bool LoadMainMenu = false;

    private void Start()
    {
        slideNb = 0;
        ShowSlide();
    }

    void ShowSlide()
    {
        if (slideNb < Slides.Length)
        {
            for (int i = 0; i < Slides.Length; i++)
            {
                if (i != slideNb)
                    Slides[i].SetActive(false);
                else
                    Slides[i].SetActive(true);
            }
        }
        else
        {
            LeaveSystem();
        }
    }

    public void NextButton()
    {
        slideNb++;
        ShowSlide();
    }

    void LeaveSystem()
    {
        if (LoadMainMenu)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            //GameplayManager.instance.HideDiseaseInformationsAndMoveon();
        }
    }
}