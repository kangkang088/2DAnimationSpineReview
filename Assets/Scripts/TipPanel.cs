using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TipPanel : MonoBehaviour
{
    public Button btnCancel;
    public Button btnNext;
    public Image imageSprite;
    // Start is called before the first frame update
    void Start()
    {
        btnCancel.onClick.AddListener(() => 
        {
            if(LevelManager.Instance.currentLevel == 2) {
                SceneManager.LoadScene("GameScene1");
                LevelManager.Instance.currentLevel--;
            }
            else {
                SceneManager.LoadScene("BeginScene");
            }
                
        });
        btnNext.onClick.AddListener(() => 
        {
            if(LevelManager.Instance.currentLevel == 1) {
                SceneManager.LoadScene("GameScene2");
                LevelManager.Instance.currentLevel++;
            }
            else {
                SceneManager.LoadScene("BeginScene");
                LevelManager.Instance.currentLevel = 1;
            }
        });
        imageSprite.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        imageSprite.fillAmount += Time.deltaTime;
        if(imageSprite.fillAmount >= 1) {
            imageSprite.fillAmount = 1;
            imageSprite.GetComponent<Animator>().enabled = true;
        }
    }
    public void ShowMe() {
        this.gameObject.SetActive(true);
    }

}
