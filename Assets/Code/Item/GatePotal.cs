using UnityEngine;
using UnityEngine.SceneManagement;

// 체력을 회복하는 아이템
public class GatePotal : MonoBehaviour, IItem
{
    public string nextScene; // 다음 씬

    public void Use(GameObject target)
    {
        GameManager.Instance.StageClear();
        SceneManager.LoadScene(nextScene);  // 씬의 이름을 넘겨 로드
        Destroy(gameObject);
    }
}