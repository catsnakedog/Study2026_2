using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isFirstPerson = false;
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        // 기존 예제와 같은 입력과 Transform 이동입니다.
        Vector3 move = Vector3.zero;
        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) move.z += 1f;
        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) move.z -= 1f;
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) move.x -= 1f;
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) move.x += 1f;

        // 바라보는 방향을 기준으로 앞뒤, 좌우로 이동합니다.
        transform.position += (transform.rotation * move.normalized) * moveSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        // Trigger는 bool만 변경하고, 캐릭터가 카메라 상태를 적용합니다.
        firstPersonCamera.enabled = isFirstPerson;
        thirdPersonCamera.enabled = !isFirstPerson;
    }
}
