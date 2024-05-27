using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class OpenLevel : MonoBehaviour
{
    [SerializeField] private Transform[] buttons;


    private void Start()
    {
        YandexGame.LoadProgress();
        int LastOpenLevel = YandexGame.savesData.LastOpenLevel;
        for (int i = 0; i <= LastOpenLevel; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
    }

}
