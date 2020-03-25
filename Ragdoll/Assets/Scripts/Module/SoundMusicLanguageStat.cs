using UnityEngine;
using System.Collections;

[SerializeField]
public class SoundMusicLanguageStat
{
    public bool SOUND;
    public bool MUSIC;
    public int LANGUAGE;

    public SoundMusicLanguageStat(bool SOUND, bool MUSIC, int LANGUAGE)
    {
        this.SOUND = SOUND;
        this.MUSIC = MUSIC;
        this.LANGUAGE = LANGUAGE;
    }
}
