using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class MainUI : MonoBehaviour
{
    [SerializeField] private UnitLocationBase unitLocationBase;
    [SerializeField] public TextMeshProUGUI HealthBase;
    [SerializeField] public Transform WindowAncoumets;
    [SerializeField] public Transform WindowSettings;
    [SerializeField] public Transform WindowShowAds;
    [SerializeField] public Transform ButtonContinueAds;
    [SerializeField] private TextMeshProUGUI titleWindowAncoumets;
    [SerializeField] public TextMeshProUGUI TimerTextAds;
    [SerializeField] private Button nextLevel;
    [SerializeField] private TextMeshProUGUI MoneyText;
    [SerializeField] public int addMoney = 1;
    [SerializeField] public Image FieldWaveImage;
    [SerializeField] private SpawnEnemy spawnEnemy;
    [SerializeField] TextMeshProUGUI TextWave;
    public int totalMoney = 60;
    private float elapsedTime = 0f;
    private float pointStart = 0f;

    [field: SerializeField] static public MainUI Instance { private set; get; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        UpdateTotalMoney();
        ShowLose();
        ShowWin();
        FilingImageWave();
        UpdateTextWave();
    }
    public void UpdateTotalMoney()
    {
        if (MoneyText != null)
        {
            MoneyText.SetText($"{totalMoney}");
        }
    }
    public void UpMoney()
    {
        totalMoney += addMoney;
    }
    public void ShowLose()
    {
        if (unitLocationBase != null)
        {
            if (unitLocationBase.stats.Health <= 0)
            {
                Time.timeScale = 0f;
                WindowAncoumets.gameObject.SetActive(true);
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    titleWindowAncoumets.SetText("Попробуй снова!");

                }
                else if (YandexGame.EnvironmentData.language == "en")
                {
                    titleWindowAncoumets.SetText("Try again!");
                }
                else if (YandexGame.EnvironmentData.language == "tr")
                {
                    titleWindowAncoumets.SetText("Tekrar dene!");
                }

                if (nextLevel != null)
                {
                    nextLevel.gameObject.SetActive(false);
                }
            }
        }
    }
    public void ShowWin()
    {
        if (spawnEnemy != null)
        {
            if (spawnEnemy.maxWaves - (spawnEnemy.curentWave - 1) == 0 && spawnEnemy.unitEnemies.Count <= 0)
            {
                Time.timeScale = 0f;
                WindowAncoumets.gameObject.SetActive(true);
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    titleWindowAncoumets.SetText("Победа!");

                }
                else if (YandexGame.EnvironmentData.language == "en")
                {
                    titleWindowAncoumets.SetText("Victory!");
                }
                else if (YandexGame.EnvironmentData.language == "tr")
                {
                    titleWindowAncoumets.SetText("Zafer!");
                }
                if (nextLevel != null)
                {
                    nextLevel.gameObject.SetActive(true);
                }
                Save();
            }
        }
    }
    public void StopGame()
    {
        Time.timeScale = 0f;
    }
    public void RunGame()
    {
        Time.timeScale = 1f;
    }
    public void FilingImageWave()
    {
        if (spawnEnemy != null)
        {
            float wave = (1f / spawnEnemy.maxWaves) * spawnEnemy.curentWave; // 0.0033

            if (spawnEnemy.GetInfoWave().WaitDestroyEnemy && spawnEnemy.unitEnemies.Count <= 0)
            {
                elapsedTime += Time.deltaTime;

                pointStart = (1f / spawnEnemy.maxWaves) * (spawnEnemy.curentWave - 1);

                // Проверяем, не превышено ли время
                if (elapsedTime < spawnEnemy.GetInfoWave().DelaySpawn)
                {
                    // Интерполируем значение endDistance от 0 до chapterDistance
                    FieldWaveImage.fillAmount = Mathf.Lerp(pointStart, wave, elapsedTime / spawnEnemy.GetInfoWave().DelaySpawn);
                }

            }
            else
            {
                elapsedTime = 0f;
            }
        }
    }
    public void UpdateTextWave()
    {
        if (TextWave != null)
        {
            TextWave.SetText($"{spawnEnemy.curentWave - 1}/{spawnEnemy.maxWaves}");
        }
    }
    public void Save()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (YandexGame.savesData.LastOpenLevel < index)
        {
            YandexGame.savesData.LastOpenLevel = index;
            YandexGame.SaveProgress();
        }
    }
}
