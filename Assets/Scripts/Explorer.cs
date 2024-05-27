using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Explorer : MonoBehaviour
{
    [SerializeField] public UnityAction UnityAction;
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Repit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoTo(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void AddClick()
    {
        if (AdsProvider.Instance != null)
        {
            MainUI.Instance.StopGame();
            AdsProvider.Instance.SkipRewarded();
        }
    }
}
