using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginPanel : MonoBehaviour
{
    public Button btnSettings;
    public Button btnStart;
    public Button btnQuit;
    private void Awake() {
        MusicDataManager.Instance.audioSource = GameObject.Find("MainCamera").GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MusicDataManager.Instance.PlayMusic(MusicDataManager.Instance.musics[MusicDataManager.Instance.musicData.id],MusicDataManager.Instance.musicData.id);
        btnSettings.onClick.AddListener(() => {
            Instantiate(Resources.Load<GameObject>("SettingPanel"),GameObject.Find("Canvas").transform);
        });
        btnStart.onClick.AddListener(() => {
            SceneManager.LoadScene("GameScene1");
        });
        btnQuit.onClick.AddListener(() => {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy() {
    }
}
