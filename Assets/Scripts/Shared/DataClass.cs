using UnityEngine;

public class DataClass
{
    public static int CONFIG_COUNT_DOWN_START = 3;
    public static Transform CHARACTER_TRANSFORM;
    public static float CONFIG_COUNT_DOWNT_MAX = 3;

    public static bool IS_CONTINUE = false;
    public static bool AD_VIWED = false;
    public static int HIGH_SCORE
    {
        get
        {
            return PlayerPrefs.GetInt("HIGH_SCORE");
        }
        set
        {
            PlayerPrefs.SetInt("HIGH_SCORE", value);
            PlayerPrefs.Save();
        }
    }

    public static string SETTINGS_LANGUAGE
    {
        get
        {
            return (PlayerPrefs.GetString("LANGUAGE") != string.Empty) ? PlayerPrefs.GetString("LANGUAGE") : "es";
        }
        set
        {
            PlayerPrefs.SetString("LANGUAGE", value);
            PlayerPrefs.Save();
        }
    }
    public static bool SETTINGS_VOLUME_MUSIC
    {
        get
        {
            return PlayerPrefs.GetInt("VOLUME_MUSIC") == 0;
        }
        set
        {
            PlayerPrefs.SetInt("VOLUME_MUSIC", (value ? 0 : 1));
            PlayerPrefs.Save();
        }
    }

    public static bool SETTINGS_VOLUME_EFFECTS
    {
        get
        {
            return PlayerPrefs.GetInt("VOLUME_EFFECTS") == 0;
        }
        set
        {
            PlayerPrefs.SetInt("VOLUME_EFFECTS", (value ? 0 : 1));
            PlayerPrefs.Save();
        }
    }
}