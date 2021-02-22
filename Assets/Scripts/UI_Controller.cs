using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private GameObject UIPanlel;
    [SerializeField] private GameObject BackGround;
    [SerializeField] private Text VolumeText;
    [SerializeField] private AudioSource audioVolume;
    [SerializeField] private AudioSource cardVolume;
    [SerializeField] private AudioSource yeahVolume;
    

    public bool VolumeToggle = true;
    public void MenuButton()
    {
        Time.timeScale = 0f;
        UIPanlel.SetActive(true);
        
    }
    public void ContinueButton()
    {
        Time.timeScale = 1f;
        UIPanlel.SetActive(false);
        
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void VolumeButton()
    {
        if (VolumeToggle)
        {
            audioVolume.Pause();
            VolumeText.text = "Volume:Off";
            VolumeToggle = false;
        }
        else 
        {
            audioVolume.Play();
            VolumeText.text = "Volume:On";
            VolumeToggle = true;
        }
    }

    public void MusicVolume(float volume)
    {
        audioVolume.volume = volume;
        
    }

    public void EffectsVolume(float volume)
    {
        cardVolume.volume = volume;
        yeahVolume.volume = volume;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
