using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public AudioClip itemPickupClip;
    private AudioSource playerAudioPlayer;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerAudioPlayer = GetComponent<AudioSource>();
        playerHealth.OnDeath += HandleDeath;
        GameManager.Instance.AddScore(0);
        Cursor.visible = false;

    }

    private void HandleDeath()
    {
        GameManager.Instance.EndGame();
        Cursor.visible = true;
    }

    public void Respawn()
    {
        gameObject.SetActive(false);
        transform.position = Utility.GetRandomPointOnNavMesh(transform.position, 30f, NavMesh.AllAreas);

        gameObject.SetActive(true);
        Cursor.visible = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        // 아이템과 충돌한 경우 해당 아이템을 사용하는 처리
        // 사망하지 않은 경우에만 아이템 사용가능
        if (!playerHealth.dead)
        {
            // 충돌한 상대방으로 부터 Item 컴포넌트를 가져오기 시도
            var item = other.GetComponent<IItem>();

            // 충돌한 상대방으로부터 Item 컴포넌트가 가져오는데 성공했다면
            if (item != null)
            {
                // Use 메서드를 실행하여 아이템 사용
                item.Use(gameObject);
                // 아이템 습득 소리 재생
                if (!other.transform.CompareTag("Potal"))
                {
                    playerAudioPlayer.PlayOneShot(itemPickupClip);
                }
            }
        }
    }
}
