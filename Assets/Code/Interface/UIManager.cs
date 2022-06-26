using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /* ✨싱글톤 */
    private static UIManager instance; // 싱글톤. private.

    public static UIManager Instance  // 이 프로퍼티를 통해서 UIManager의 싱글톤 private 인스턴스를 리턴 받음.
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<UIManager>();  // 인스턴스가 이미 존재할 땐 받지 않는다. 즉, null 일때만 받음.

            return instance;
        }
    }

    // UHD Canvas 의 구성 UI 요소들.
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;

    public void UpdateScoreText(int newScore)  // 'scoreText' 점수 UI 갱신
    {
        scoreText.text = newScore + " Score";
    }


    public void UpdateHealthText(float health) // 'healthText' 남은 HP UI 갱신
    {
        healthText.text = (Mathf.Floor(health).ToString()) + " HP"; // 체력의 소숫점을 내림한 후 문자열로 바꿈
    }

    public void SetActiveGameoverUI(bool active) // 게임 오버시 'GameOver' UI 활성화
    {
        gameoverUI.SetActive(active);
    }

    public void GameRestart()  // 게임 Over 상태에서 Restart 버튼을 눌렀을 때 실행시킬 함수. 게임 재 시작
    {
        GameManager.Instance.RestartSet();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // 현재 씬의 이름을 넘겨 다시 로드
    }
}
