using UnityEngine;
using UnityEngine.SceneManagement;

// ü���� ȸ���ϴ� ������
public class GatePotal : MonoBehaviour, IItem
{
    public string nextScene; // ���� ��

    public void Use(GameObject target)
    {
        GameManager.Instance.StageClear();
        SceneManager.LoadScene(nextScene);  // ���� �̸��� �Ѱ� �ε�
        Destroy(gameObject);
    }
}