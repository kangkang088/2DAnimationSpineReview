using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDataManager
{
    private static MusicDataManager instance = new MusicDataManager();
    public static MusicDataManager Instance => instance;
    public MusicData musicData = null;
    public AudioClip clip;
    public List<string> musics = new List<string>();
    public AudioSource audioSource = GameObject.Find("MainCamera").GetComponent<AudioSource>();

    private MusicDataManager() {
        musicData = new MusicData();
        for(int i = 0;i < 3;i++) {
            musics.Add("music" + (i + 1));
        }
    }
    public void PlayMusic(string musicName,int id) {
        musicData.musicName = musicName;
        musicData.id = id;
        clip = Resources.Load<AudioClip>(musicName);
        audioSource.clip = clip;
        audioSource.Play();
        
    }
    public void SetMusicVolume(float value) {
        musicData.volume = value;
        GameObject.Find("MainCamera").GetComponent<AudioSource>().volume = value;
    }
}
