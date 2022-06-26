using UnityEngine;

// ü���� ȸ���ϴ� ������
public class HealthPack : MonoBehaviour, IItem
{
    public float health; // ü���� ȸ���� ��ġ

    public void Use(GameObject target)
    {
        // ���޹��� ���� ������Ʈ�κ��� LivingEntity ������Ʈ �������� �õ�
        var life = target.GetComponent<LivingEntity>();

        // LivingEntity������Ʈ�� �ִٸ�
        if (life != null)
        // ü�� ȸ�� ����
        {
            life.RestoreHealth(health);
        }

        // ���Ǿ����Ƿ�, �ڽ��� �ı�
        Destroy(gameObject);
    }
}