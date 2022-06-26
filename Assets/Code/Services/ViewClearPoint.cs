using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewClearPoint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalScore;
    [SerializeField] private TextMeshProUGUI totalSpecial;
    [SerializeField] private TextMeshProUGUI totalTotem;
    // Start is called before the first frame update
    void Start()
    {
        totalScore.text = "��ü ����: " + GameManager.Instance.GetScore().ToString() + "P";
        totalSpecial.text = "���� ���� ������: " + GameManager.Instance.GetSpecialCount().ToString() + "��";
        totalTotem.text = "�ı��� ����: " + GameManager.Instance.GetTotem().ToString() + "��";
    }
}
