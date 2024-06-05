using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    public Slider sliderMusic;
    public Button btnLeft;
    public Button btnRight;
    public Button btnClose;
    public Text textMusic;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        Init();   
        sliderMusic.onValueChanged.AddListener((value) => {
            MusicDataManager.Instance.SetMusicVolume(value);
        });
        btnClose.onClick.AddListener(() => {
            Destroy(this.gameObject);
        });
        btnRight.onClick.AddListener(() => {
            index++;
            if(index >= MusicDataManager.Instance.musics.Count) {
                index = 0;
            }
            MusicDataManager.Instance.PlayMusic(MusicDataManager.Instance.musics[index],index);
            SetText(MusicDataManager.Instance.musics[index]);
        });
        btnLeft.onClick.AddListener(() => {
            index--;
            if(index < 0) {
                index = MusicDataManager.Instance.musics.Count - 1;
            }
            MusicDataManager.Instance.PlayMusic(MusicDataManager.Instance.musics[index],index);
            SetText(MusicDataManager.Instance.musics[index]);
        });
    }
    public void Init() {
        SetText(MusicDataManager.Instance.musicData.musicName);
        index = MusicDataManager.Instance.musicData.id;
        sliderMusic.value = MusicDataManager.Instance.musicData.volume;
    }
    public void SetText(string content) {
        textMusic.text = content;
    }

}
