using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    public int score;

    public void Use(GameObject target)
    {
        GameManager.Instance.AddScore(score);
        Debug.Log("ÄÚÀÎ");
        Destroy(gameObject);
    }
}