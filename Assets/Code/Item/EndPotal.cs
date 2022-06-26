using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPotal : MonoBehaviour, IItem
{
    public int endingCount;
    public int endingDestroy;
    public string nextSceneBad; // ��忣��
    public string nextSceneTrue; // Ʈ�翣��

    public void Use(GameObject target)
    {
        GameManager.Instance.StageClear();
        int GSC_num = GameManager.Instance.GetSpecialCount();
        int GT_num = GameManager.Instance.GetTotem();
        if (endingCount <= GSC_num && endingDestroy <= GT_num) { //Ʈ�� ����
            SceneManager.LoadScene(nextSceneTrue);  // ���� �̸��� �Ѱ� �ε�
        }
        else { //��Ʈ ����
            SceneManager.LoadScene(nextSceneBad);  // ���� �̸��� �Ѱ� �ε�
        }
        Destroy(gameObject);
    }
}
