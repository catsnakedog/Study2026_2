using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        // 1. 키 입력을 이동 방향으로 바꿉니다.
        Vector3 move = Vector3.zero;
        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) move.z += 1f;
        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) move.z -= 1f;
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) move.x -= 1f;
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) move.x += 1f;

        // 2. 캐릭터의 현재 회전을 이동 방향에 적용해서 이동합니다.
        // normalized는 대각선 이동도 같은 속도가 되게 합니다.
        transform.position += (transform.rotation * move.normalized) * moveSpeed * Time.deltaTime;

        // 3. Space를 누를 때마다 발사 위치에 총알 프리팹을 생성합니다.
        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
