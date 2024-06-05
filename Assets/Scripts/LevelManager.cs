using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager
{
    private static LevelManager instance = new LevelManager();
    public static LevelManager Instance => instance;
    public int condition = 0;
    public int conditionMax = 3;
    public int currentLevel = 1;
    private LevelManager() {
        
    }
    public bool IsCompleted() {
        return condition == conditionMax ? true : false;
    }
}
