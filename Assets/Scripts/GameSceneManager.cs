using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSceneManager
{
    public enum Scene { 
        GameScene,
        MainMenuAptos,
    }
    public static void Load(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }
}
