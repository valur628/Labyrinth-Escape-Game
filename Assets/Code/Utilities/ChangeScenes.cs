using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public string nextScene; // ¥Ÿ¿Ω æ¿
    public void Update() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void SceneChanges()
    {
        Debug.Log(nextScene + " Scene Movement");
        SceneManager.LoadScene(nextScene);
    }
}