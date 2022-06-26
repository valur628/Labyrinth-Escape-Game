using System.Collections.Generic;
using UnityEngine;

// �� ���� ������Ʈ�� �ֱ������� ����
public class EnemySpawner : MonoBehaviour
{
    private readonly List<Enemy> enemies = new List<Enemy>(); // ������ ������ ��� ����Ʈ

    public float damageMax = 40f; // �ִ� ���ݷ�
    public float damageMin = 20f; // �ּ� ���ݷ�
    public Enemy enemyPrefab; // ������ �� AI

    public float healthMax = 200f; // �ִ� ü��
    public float healthMin = 100f; // �ּ� ü��

    public Transform[] spawnPoints; // �� AI�� ��ȯ�� ��ġ��

    public float speedMax = 12f; // �ִ� �ӵ�
    public float speedMin = 3f; // �ּ� �ӵ�

    public Color strongEnemyColor = Color.red; // ���� �� AI�� ������ �� �Ǻλ�
    private int wave; // ���� ���̺�

    private void Update()
    {
        // ���� ���� �����϶��� �������� ����
        if (GameManager.Instance != null && GameManager.Instance.isGameover) return;

        // ���� ��� ����ģ ��� ���� ���� ����
        if (enemies.Count <= 0) SpawnWave();

        // UI ����
        UpdateUI();
    }

    // ���̺� ������ UI�� ǥ��
    private void UpdateUI()
    {
        // ���� ���̺�� ���� ���� �� ǥ��
    }

    // ���� ���̺꿡 ���� ���� ����
    private void SpawnWave()
    {
        // ���̺� 1 ����
        wave++;

        // ���� ���̺� * 1.5�� �ݿø� �� ���� ��ŭ ���� ����
        var spawnCount = Mathf.RoundToInt(wave * 15f);

        // spawnCount ��ŭ ���� ����
        for (var i = 0; i < spawnCount; i++)
        {
            // ���� ���⸦ 0%���� 100% ���̿��� ���� ����
            var enemyIntensity = Random.Range(0f, 1f);
            // �� ���� ó�� ����
            CreateEnemy(enemyIntensity);
        }
    }

    // ���� �����ϰ� ������ ������ ������ ����� �Ҵ�
    private void CreateEnemy(float intensity)
    {
        // intensity�� ������� ���� �ɷ�ġ ����
        var health = Mathf.Lerp(healthMin, healthMax, intensity);
        var damage = Mathf.Lerp(damageMin, damageMax, intensity);
        var speed = Mathf.Lerp(speedMin, speedMax, intensity);

        // intensity�� ������� �Ͼ���� enemyStrength ���̿��� ���� �Ǻλ� ����
        var skinColor = Color.Lerp(Color.white, strongEnemyColor, intensity);

        // ������ ��ġ�� �������� ����
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // �� ���������κ��� �� ����
        var enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // ������ ���� �ɷ�ġ�� ���� ��� ����
        enemy.Setup(health, damage, speed, speed * 0.3f, skinColor);

        // ������ ���� ����Ʈ�� �߰�
        enemies.Add(enemy);

        // ���� onDeath �̺�Ʈ�� �͸� �޼��� ���
        // ����� ���� ����Ʈ���� ����
        enemy.OnDeath += () => enemies.Remove(enemy);
        // ����� ���� 10 �� �ڿ� �ı�
        enemy.OnDeath += () => Destroy(enemy.gameObject, 10f);
        // �� ����� ���� ���
        enemy.OnDeath += () => GameManager.Instance.AddScore(100);
    }
}
