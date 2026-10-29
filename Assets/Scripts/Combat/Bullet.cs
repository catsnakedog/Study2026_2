using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 3f;

    void Start()
    {
        // 생성될 때 Rigidbody에 앞쪽 방향의 속도를 한 번 더합니다.
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);

        // 아무것도 맞히지 않아도 일정 시간이 지나면 제거합니다.
        Destroy(gameObject, lifeTime);
    }

    // 충돌시 삭제
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
