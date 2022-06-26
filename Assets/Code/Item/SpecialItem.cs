using UnityEngine;

public class SpecialItem : MonoBehaviour, IItem
{
    public int countSpecial;

    public void Use(GameObject target)
    {
        GameManager.Instance.AddSpecialCount(countSpecial);
        Destroy(gameObject);
    }
}
