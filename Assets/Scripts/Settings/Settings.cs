using System;
using System.Collections;
using System.Collections.Generic;
using EvolveGames;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _settingsCanvas;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private PlayerController _controller;

    [SerializeField] private Slider _sensetivitySlider;
    [SerializeField] private Slider MasterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _effectsVolumeSlider;

    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private TMP_Dropdown _displayDropdown;

    [SerializeField] private string _onText;
    [SerializeField] private string _offText;

    [SerializeField] private TextMeshProUGUI _fullScreenOnOffTText;

    [SerializeField] private TextMeshProUGUI _sensetivityValueText;
    [SerializeField] private TextMeshProUGUI _musicVolumeValueText;
    [SerializeField] private TextMeshProUGUI _effectsVolumeValueText;
    [SerializeField] private TextMeshProUGUI _masterVolumeValueText;

    private Resolution[] _resolutions;
    private List<Resolution> _filteredResolutions;
    private float _currentRefrashRate;
    private int _currentResolutionIndex = 0;
    private int _monitorCount;
    private int _monitorIndex;

    public event Action Opened;
    public event Action Closed;

    public bool Open { get; private set; } = false;

    public static Settings Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }


        Debug.LogError(gameObject);
        Debug.LogError("There`s one more settings");
        Debug.Break();
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        _monitorCount = Display.displays.Length;

        _sensetivitySlider.value = PlayerPrefs.GetFloat("Sensetivity", 2f);

        MasterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1);
        _musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        _effectsVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1);
        bool fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullScreen", 1));
        Screen.SetResolution(PlayerPrefs.GetInt("Width"), PlayerPrefs.GetInt("Height"), fullScreen);
        SetResolutionReady();
        BootstrapDisplay();
        Display.displays[PlayerPrefs.GetInt("Display", _monitorIndex)].Activate();
        Screen.fullScreen = fullScreen;
        if (fullScreen)
        {
            _fullScreenOnOffTText.text = _offText;
        }
        else
        {
            _fullScreenOnOffTText.text = _onText;
        }
    }

    public void OpenCloseSettings()
    {
        _settingsCanvas.SetActive(!_settingsCanvas.activeSelf);
        Open = _settingsCanvas.activeSelf;
        if (_settingsCanvas.activeSelf)
        {
            Time.timeScale = 0;
            Opened?.Invoke();
        }
        else
        {
            Time.timeScale = 1;
            Closed?.Invoke();
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenCloseSettings();
        }
    }

    public void OnSensetivitySliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat("Sensetivity", value);
        if (_controller != null)
            _controller.lookSpeed = value;

        _sensetivityValueText.text = value.ToString("0.00");
    }

    public void OnMasterVolumeSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat("MasterVolume", value);
        if (value == 0)
        {
            _mixer.SetFloat("MasterVolume", -80);
        }
        else
        {
            _mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
        }

        _masterVolumeValueText.text = value.ToString("0.00");
    }

    public void OnMusicVolumeSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        if (value == 0)
        {
            _mixer.SetFloat("MusicVolume", -80);
        }
        else
        {
            _mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        }

        _musicVolumeValueText.text = value.ToString("0.00");
    }

    public void OnEffectsVolumeSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat("EffectVolume", value);

        if (value == 0)
        {
            _mixer.SetFloat("EffectVolume", -80);
        }
        else
        {
            _mixer.SetFloat("EffectVolume", Mathf.Log10(value) * 20);
        }

        _effectsVolumeValueText.text = value.ToString("0.00");
    }

    public void SetResolutionReady()
    {
        _resolutions = Screen.resolutions;
        _filteredResolutions = new List<Resolution>();

        _resolutionDropdown.ClearOptions();
        _currentRefrashRate = Screen.currentResolution.refreshRate;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            if (_resolutions[i].refreshRate == _currentRefrashRate)
            {
                _filteredResolutions.Add(_resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < _filteredResolutions.Count; i++)
        {
            string resolutionOption = _filteredResolutions[i].width + "x" + _filteredResolutions[i].height + " " +
                                      _filteredResolutions[i].refreshRate + "Hz";
            options.Add(resolutionOption);
            if (_filteredResolutions[i].width == Screen.width && _filteredResolutions[i].height == Screen.height)
            {
                _currentResolutionIndex = i;
            }
        }

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = _currentResolutionIndex;
        _resolutionDropdown.RefreshShownValue();
    }

    public void BootstrapDisplay()
    {
        _displayDropdown.ClearOptions();
        List<string> display = new List<string>();
        _monitorCount = Display.displays.Length;
        if (_monitorCount <= 1)
        {
            Display.displays[0].Activate();
            string displayName = "Display" + " " + _monitorIndex;
            display.Add(displayName);
        }
        else
        {
            for (int i = 1; i < _monitorCount; i++)
            {
                _monitorIndex = i;
                string displayName = "Display" + " " + _monitorIndex;
                display.Add(displayName);
                if (Display.displays[i].active)
                {
                    Display.displays[i].Activate();
                    Display.displays[i].SetRenderingResolution(Display.displays[i].systemWidth,
                        Display.displays[i].systemHeight);
                }
            }
        }

        _displayDropdown.AddOptions(display);
        _displayDropdown.value = _monitorCount;
        _displayDropdown.RefreshShownValue();
        PlayerPrefs.SetInt("Display", _monitorIndex);
    }

    public void SwitchDisplay(int displayIndex)
    {
        Display.displays[displayIndex].Activate();
        Display.displays[displayIndex].SetRenderingResolution(Display.displays[displayIndex].systemWidth,
            Display.displays[displayIndex].systemHeight);
        SetResolutionReady();
    }

    public void ChangeResolutions(int resolutionIndex)
    {
        Resolution resolution = _filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
        PlayerPrefs.SetInt("Height", resolution.height);
        PlayerPrefs.SetInt("Width", resolution.width);
    }

    public void SwitchFullScreenSettings()
    {
        if (!Screen.fullScreen)
        {
            Screen.fullScreen = true;
            PlayerPrefs.SetInt("FullScreen", 1);
        }
        else
        {
            Screen.fullScreen = false;
            PlayerPrefs.SetInt("FullScreen", 0);
        }
    }

    public void OnOffText(TextMeshProUGUI text)
    {
        if (text.text == _onText)
            text.text = _offText;
        else
            text.text = _onText;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}