using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject volumeMenu;
    [SerializeField] GameObject graphicsMenu;
    [SerializeField] GameObject screenMenu;
    [SerializeField] GameObject resolutionMenu;
    [SerializeField] AudioSource awakeStatic;
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Camera cam;

    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    public void SetVolume(float _value)
    {
        if(_value < 1)
        {
            _value = 0.001f;
        }

        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        PlayerPrefs.SetFloat("SavedMusicVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 10) * 20f);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float _value)
    {
        soundSlider.value = _value; 
    }

    public void backButton()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        awakeStatic.Play();
        cam.transform.position = new Vector3(1.88399994f, 0.523999989f, -9.09599972f);
        cam.transform.rotation = Quaternion.Euler(-20.669f, -31.949f, 2.921f);
        Debug.Log("Back");
    }

    public void volumeOption()
    {
            volumeMenu.SetActive(true);
            graphicsMenu.SetActive(false);
            screenMenu.SetActive(false);
            resolutionMenu.SetActive(false);
    }
    public void graphicsOption()
    {
        volumeMenu.SetActive(false);
        graphicsMenu.SetActive(true);
        screenMenu.SetActive(false);
        resolutionMenu.SetActive(false);
    }
    public void screenOption()
    {
        volumeMenu.SetActive(false);
        graphicsMenu.SetActive(false);
        screenMenu.SetActive(true);
        resolutionMenu.SetActive(false);
    }
    public void resolutionOption()
    {
        volumeMenu.SetActive(false);
        graphicsMenu.SetActive(false);
        screenMenu.SetActive(false);
        resolutionMenu.SetActive(true);
    }

    public void fullscreen()
    {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        Debug.Log("Fullscreen");
    }
    public void borderless()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        Debug.Log("Borderless");
    }
    public void windowed()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Debug.Log("Windowed");
    }

    public void LowQ()
    {
        QualitySettings.SetQualityLevel(0, true);
        Debug.Log(QualitySettings.currentLevel);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
    public void MediumQ()
    {
        QualitySettings.SetQualityLevel(1, true);
        Debug.Log(QualitySettings.currentLevel);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
    public void HighQ()
    {
        QualitySettings.SetQualityLevel(2, true);
        Debug.Log(QualitySettings.currentLevel);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
    public void UltraQ()
    {
        QualitySettings.SetQualityLevel(3, true);
        Debug.Log(QualitySettings.currentLevel);
        Debug.Log(QualitySettings.GetQualityLevel());
    }

    public void TwoFive()
    {
        Screen.SetResolution(2560, 1440, false);
        Debug.Log(Screen.currentResolution);
    }
    public void OneNine()
    {
        Screen.SetResolution(1920, 1080, false);
        Debug.Log(Screen.currentResolution);
    }
    public void OneSix()
    {
        Screen.SetResolution(1680, 1050, false);
        Debug.Log(Screen.currentResolution);
    }
    public void OneFour()
    {
        Screen.SetResolution(1440, 900, false);
        Debug.Log(Screen.currentResolution);
    }
    public void OneTwo()
    {
        Screen.SetResolution(1280, 800, false);
        Debug.Log(Screen.currentResolution);
    }
    public void OneNill()
    {
        Screen.SetResolution(1024, 768, false);
        Debug.Log(Screen.currentResolution);
    }
    public void EightNill()
    {
        Screen.SetResolution(800, 600, false);
        Debug.Log(Screen.currentResolution);
    }
    public void SixFour()
    {
        Screen.SetResolution(640, 480, false);
        Debug.Log(Screen.currentResolution);
    }
}
