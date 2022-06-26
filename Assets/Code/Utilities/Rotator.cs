using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;  // 초당 회전 속도

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);  // y 축으로 1 초에 60도씩 회전
    }
}
