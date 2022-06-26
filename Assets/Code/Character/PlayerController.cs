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
        // �����۰� �浹�� ��� �ش� �������� ����ϴ� ó��
        // ������� ���� ��쿡�� ������ ��밡��
        if (!playerHealth.dead)
        {
            // �浹�� �������� ���� Item ������Ʈ�� �������� �õ�
            var item = other.GetComponent<IItem>();

            // �浹�� �������κ��� Item ������Ʈ�� �������µ� �����ߴٸ�
            if (item != null)
            {
                // Use �޼��带 �����Ͽ� ������ ���
                item.Use(gameObject);
                // ������ ���� �Ҹ� ���
                if (!other.transform.CompareTag("Potal"))
                {
                    playerAudioPlayer.PlayOneShot(itemPickupClip);
                }
            }
        }
    }
}
