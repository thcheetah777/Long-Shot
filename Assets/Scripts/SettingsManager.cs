using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    public Toggle sfxToggle;
    public Toggle musicToggle;

    void OnEnable() {
        sfxToggle.isOn = GetSettings("sfxEnabled");
        musicToggle.isOn = GetSettings("musicEnabled");
    }

    static public bool GetSettings(string settingName) {
        return PlayerPrefs.GetInt(settingName, 1) > 0 ? true : false;
    }

    public void UpdateSettings(Toggle toggle) {
        string settingName = toggle.name == "SFX Toggle" ? "sfxEnabled" : "musicEnabled";
        PlayerPrefs.SetInt(settingName, toggle.isOn ? 1 : 0);
    }

}
