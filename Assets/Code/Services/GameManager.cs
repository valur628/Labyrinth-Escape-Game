using UnityEngine;

// 점수와 게임 오버 여부, 게임 UI를 관리하는 게임 매니저
public class GameManager : MonoBehaviour
{
    private static GameManager instance = null; // 싱글톤이 할당될 static 변수
    public bool isGameover {
        get;
        private set;
    } // 게임 오버 상태

    // 외부에서 싱글톤 오브젝트를 가져올때 사용할 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (instance == null)
                // 씬에서 GameManager 오브젝트를 찾아 할당
                instance = FindObjectOfType<GameManager>();

            // 싱글톤 오브젝트를 반환
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면 자신을 파괴
            if (instance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
            {
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
                return;
            }
        }
        scoreTemp = score;
        itemSpecialCountTemp = itemSpecialCount;
        totemDestroyedTemp = 0;
    }

    public void RestartSet()
    {
        isGameover = false;
        scoreTemp = score;
        itemSpecialCountTemp = itemSpecialCount;
        totemDestroyedTemp = 0;
    }


    // 점수를 추가하고 UI 갱신
    public void AddScore(int newScore)
    {
        Debug.Log("ddd");
        // 게임 오버가 아닌 상태에서만 점수 증가 가능
        if (!isGameover)
        {
            // 점수 추가
            scoreTemp += newScore;
            // 점수 UI 텍스트 갱신
            UIManager.Instance.UpdateScoreText(scoreTemp);
        }
    }

    // 점수를 얻음
    public int GetScore() {
        return score;
    }

    // 개수를 추가하고 UI 갱신
    public void AddSpecialCount(int newCount)
    {
        // 게임 오버가 아닌 상태에서만 개수 증가 가능
        if (!isGameover)
        {
            // 특수 아이템 개수 추가
            itemSpecialCountTemp += newCount;
        }
    }

    // 개수를 얻음
    public int GetSpecialCount()
    {
        return itemSpecialCount;
    }

    // 토템을 추가하고 UI 갱신
    public void AddTotem(int newTotem)
    {
        // 게임 오버가 아닌 상태에서만 토템 증가 가능
        if (!isGameover)
        {
            // 토템 개수 추가
            totemDestroyedTemp += newTotem;
        }
    }

    // 토템을 얻음
    public int GetTotem()
    {
        return totemDestroyed;
    }

    // 모두 초기화
    public void ResetAll()
    {
        score = 0;
        itemSpecialCount = 0;
        totemDestroyed = 0;
    }

    // 게임 오버 처리
    public void EndGame()
    {
        // 게임 오버 상태를 참으로 변경
        isGameover = true;
        // 게임 오버 UI를 활성화
        UIManager.Instance.SetActiveGameoverUI(true);
    }

    public void StageClear()
    {
        score = scoreTemp;
        itemSpecialCount = itemSpecialCountTemp;
        totemDestroyed = totemDestroyedTemp;
    }
    public int scoreTemp; // 현재 게임 점수, 임시
    public int itemSpecialCountTemp; // 현재 특수 아이템 개수, 임시
    public int totemDestroyedTemp; // 현재 파괴한 토탬 수, 임시

    public int score; // 현재 게임 점수
    public int itemSpecialCount; // 현재 특수 아이템 개수
    public int totemDestroyed; // 현재 파괴한 토탬 수
}
