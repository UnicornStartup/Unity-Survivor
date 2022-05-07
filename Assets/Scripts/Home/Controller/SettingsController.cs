using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Image iconMusic, iconSFX;
    public void Start()
    {
        setSpriteIcon(iconMusic, "btn_icon_sound", DataClass.SETTINGS_VOLUME_MUSIC);
        setSpriteIcon(iconSFX, "icon_white_sound", DataClass.SETTINGS_VOLUME_EFFECTS);
    }
    public void changeVolumeMusic()
    {
        DataClass.SETTINGS_VOLUME_MUSIC = !DataClass.SETTINGS_VOLUME_MUSIC;
        Debug.Log(DataClass.SETTINGS_VOLUME_MUSIC);
        SoundManager.Instance.changeBSOVolumen();
        SoundManager.Instance.PlayButtonClick();
        setSpriteIcon(iconMusic, "btn_icon_sound", DataClass.SETTINGS_VOLUME_MUSIC);
    }
    public void changeVolumeEffects()
    {
        DataClass.SETTINGS_VOLUME_EFFECTS = !DataClass.SETTINGS_VOLUME_EFFECTS;
        SoundManager.Instance.PlayButtonClick();
        setSpriteIcon(iconSFX, "icon_white_sound", DataClass.SETTINGS_VOLUME_EFFECTS);
    }

    public void setSpriteIcon(Image image, string name,bool isActive)
    {
        string iconName = name + (isActive ? "" : "_mute");
        image.sprite = Resources.Load<Sprite>($"Sprites/ContainerSettings/"+ iconName);
    }

    public void cangeLanguage()
    {
        SoundManager.Instance.PlayButtonClick();
    }

}
