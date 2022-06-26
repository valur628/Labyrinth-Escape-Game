using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoResetScenes : MonoBehaviour
{
    public string nextScene; // ¥Ÿ¿Ω æ¿
    public void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void ResetScenes()
    {
        Debug.Log(nextScene + " Reset Scenes");
        GameManager.Instance.ResetAll();
        SceneManager.LoadScene(nextScene);
    }
}
