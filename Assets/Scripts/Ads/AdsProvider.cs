using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class AdsProvider : MonoBehaviour
{
    private int chekIndex;
    private float timer = 0f;
    private float timerPause = 3f;
    public static AdsProvider Instance { get; private set; }
    private void Awake()
    {
        if (!Instance)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    private void Update()
    {
        chekIndex = SceneManager.GetActiveScene().buildIndex;
        if (chekIndex != 0 && !MainUI.Instance.WindowAncoumets.gameObject.activeSelf && !MainUI.Instance.WindowSettings.gameObject.activeSelf)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 120f)
        {
            MainUI.Instance.StopGame();
            MainUI.Instance.WindowShowAds.gameObject.SetActive(true);
            MainUI.Instance.TimerTextAds.gameObject.SetActive(true);
            if (YandexGame.EnvironmentData.language == "ru")
            {
                MainUI.Instance.TimerTextAds.text = $"Реклама {MathF.Round(timerPause)}..";

            }
            else if (YandexGame.EnvironmentData.language == "en")
            {
                MainUI.Instance.TimerTextAds.text = $"Advertisement {MathF.Round(timerPause)}..";
            }
            else if (YandexGame.EnvironmentData.language == "tr")
            {
                MainUI.Instance.TimerTextAds.text = $"Reklam {MathF.Round(timerPause)}..";
            }
            timerPause -= Time.unscaledDeltaTime;
            if (timerPause <= 0)
            {
                ShowAds();
                timerPause = 3f;
                MainUI.Instance.TimerTextAds.gameObject.SetActive(false);
                MainUI.Instance.ButtonContinueAds.gameObject.SetActive(true);
                timer = 0f;
            }
        }
    }
    public void SkipRewarded()
    {
        YandexGame.RewVideoShow(0);
    }
    public void ShowAds()
    {
        if (chekIndex != 0 && !MainUI.Instance.WindowSettings.gameObject.activeSelf && !MainUI.Instance.WindowAncoumets.gameObject.activeSelf)
        {
            YandexGame.FullscreenShow();
        }
    }
    public void Click()
    {
        MainUI.Instance.RunGame();
        MainUI.Instance.addMoney += 1;
    }
    public void RunGame()
    {
        Time.timeScale = 1f;
    }
}
