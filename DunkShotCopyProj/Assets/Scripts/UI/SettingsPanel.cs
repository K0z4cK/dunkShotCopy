using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private Button _backButton;

    [SerializeField]
    private Slider _soundSlider;
    [SerializeField]
    private Slider _vibroSlider;
    [SerializeField]
    private Slider _darkModeSlider;

    private bool _isSoundOn;
    private bool _isDarkModeOn;
    private bool _isVibrationOn;

    void Awake()
    {
        _isSoundOn = true;
        _isVibrationOn = false;
        _isDarkModeOn = false;
        if (PlayerPrefs.HasKey("SoundOn"))
        {
            _isSoundOn = PlayerPrefs.GetInt("SoundOn") == 1;
        }
        PlayerPrefs.SetInt("SoundOn", _isSoundOn ? 1 : 0);
        if (PlayerPrefs.HasKey("VibrationOn"))
        {
            _isVibrationOn = PlayerPrefs.GetInt("VibrationOn") == 1;
        }
        PlayerPrefs.SetInt("VibrationOn", _isVibrationOn ? 1 : 0);
        if (PlayerPrefs.HasKey("ThemeColor"))
        {
            _isDarkModeOn = PlayerPrefs.GetInt("ThemeColor") == 1;
        }
        PlayerPrefs.SetInt("ThemeColor", _isDarkModeOn ? 1 : 0);

        _soundSlider.GetComponent<Toggle>().SetStartValue( _isSoundOn);
        _vibroSlider.GetComponent<Toggle>().SetStartValue(_isVibrationOn);
        _darkModeSlider.GetComponent<Toggle>().SetStartValue(_isDarkModeOn);

        _soundSlider.onValueChanged.AddListener(ChangeSound);
        _vibroSlider.onValueChanged.AddListener(ChangeVibro);
        _darkModeSlider.onValueChanged.AddListener(ChangeDarkMode);



        _backButton.onClick.AddListener(BackButtonClicked);
    }
    private void ChangeSound(float value)
    {
        if(_soundSlider.value == 0)
            _isSoundOn = true;
        else
            _isSoundOn = false;
        PlayerPrefs.SetInt("SoundOn", _isSoundOn ? 1 : 0);
        EventManager.Instance.SoundChanged();
    }
    private void ChangeVibro(float value)
    {
        if (_vibroSlider.value == 0)
        {
            _isVibrationOn = true;
            Handheld.Vibrate();
        }
        else
            _isVibrationOn = false;
        PlayerPrefs.SetInt("VibrationOn", _isVibrationOn ? 1 : 0);
        EventManager.Instance.VibroChanged();
    }
    private void ChangeDarkMode(float value)
    {
        EventManager.Instance.ColorChanged();
    }
    private void BackButtonClicked()
    {
        UIManager.Instance.HideSettingsPanel();
    }
}
