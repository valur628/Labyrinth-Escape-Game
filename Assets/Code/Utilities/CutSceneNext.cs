using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneNext : MonoBehaviour
{

    /*[Tooltip("Now Cut Scene.")]
    [SerializeField]
    private Image nextImage;*/

    [Tooltip("Timer Time")]
    [SerializeField]
    private float nowTime = 5f;

    [Tooltip("Before Time")]
    [SerializeField]
    private float beforeTime = 0f;

    private void Start()
    {
        //Destroy the game object in nowTime seconds
        Destroy(gameObject, beforeTime + nowTime);
    }
}