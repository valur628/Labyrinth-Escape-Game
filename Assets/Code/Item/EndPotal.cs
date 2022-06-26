using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPotal : MonoBehaviour, IItem
{
    public int endingCount;
    public int endingDestroy;
    public string nextSceneBad; // 배드엔딩
    public string nextSceneTrue; // 트루엔딩

    public void Use(GameObject target)
    {
        GameManager.Instance.StageClear();
        int GSC_num = GameManager.Instance.GetSpecialCount();
        int GT_num = GameManager.Instance.GetTotem();
        if (endingCount <= GSC_num && endingDestroy <= GT_num) { //트루 엔딩
            SceneManager.LoadScene(nextSceneTrue);  // 씬의 이름을 넘겨 로드
        }
        else { //배트 엔딩
            SceneManager.LoadScene(nextSceneBad);  // 씬의 이름을 넘겨 로드
        }
        Destroy(gameObject);
    }
}
