using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsAudio : MonoBehaviour
{
    [SerializeField] private Slider music;
    private void OnEnable()
    {
        music.value = Audio.Instance.Music.volume;
        music.onValueChanged.AddListener(SetMusicVolume);
    }
    private void OnDisable()
    {
        music.onValueChanged.RemoveListener(SetMusicVolume);
    }
    public void SetMusicVolume(float value)
    {
        Audio.Instance.Music.volume = value;
        PlayerPrefs.SetFloat("MusicValue", value);
    }
}
