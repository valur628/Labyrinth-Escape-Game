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
        totalScore.text = "전체 점수: " + GameManager.Instance.GetScore().ToString() + "P";
        totalSpecial.text = "모은 히든 아이템: " + GameManager.Instance.GetSpecialCount().ToString() + "개";
        totalTotem.text = "파괴한 토템: " + GameManager.Instance.GetTotem().ToString() + "개";
    }
}
