using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionPanelScript : MonoBehaviour
{
    public GameObject optionPanel;
    public Sprite disableMusic;
    public Sprite enableMusic;
    public Sprite enableVibration;
    public Sprite disableVibration;
    public Sprite enableSound;
    public Sprite disableSound;
    public Button musicButton;
    public Button vibrationButton;
    public Button soundButton;

    public void PanelActivation()
    {    
        optionPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void PanelDisable()
    {
        optionPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
    }
    public void MusicButton()
    {
        if (musicButton.image.sprite == enableMusic)
        {
        musicButton.image.sprite = disableMusic;
        }
        else
        {
            musicButton.image.sprite = enableMusic;
        }
    }
    public void VibrationButton()
    {
        if (vibrationButton.image.sprite == enableVibration)
        {
        vibrationButton.image.sprite = disableVibration;
        }
        else
        {
            vibrationButton.image.sprite = enableVibration;
        }
    }
    public void SoundButton()
    {
        if (soundButton.image.sprite == enableSound)
        {
        soundButton.image.sprite = disableSound;
        }
        else
        {
            soundButton.image.sprite = enableSound;
        }
    }

}
