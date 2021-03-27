using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class OptionsMenu : Menu
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private TMPro.TMP_Dropdown qualityDropdown;
    public static SettingsData SettingsData { get; set; }

    public void OnSFXsliderValueChanged( float value )
    {
        SettingsData.SFXvolume = value;
    }
    public void OnMusicSliderValueChanged( float value)
    {
        _videoPlayer.SetDirectAudioVolume(0, value);
        SettingsData.Musicvolume = value;
    }
    public void OnQualityDropDownChanged(int value)
    {
        QualitySettings.SetQualityLevel(value);
        SettingsData.QualityLvl = value;
    }

    public void OnSaveButtonClicked()
    {
        SaveManager.SaveSettings(SettingsData);
    }
    public override void Load()
    {
        CheckSettings();

        

        base.Load();
    }

    private void CheckSettings()
    {
        if (SettingsData == null)
        {
            SettingsData = new SettingsData
            {
                Musicvolume = 1,
                SFXvolume = 1,
                QualityLvl = 0
            };
        }
        else
        {
            musicSlider.value = SettingsData.Musicvolume;
            sfxSlider.value = SettingsData.SFXvolume;
            qualityDropdown.value = SettingsData.QualityLvl;
        }
    }
}
