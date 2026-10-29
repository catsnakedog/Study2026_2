using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastShooter : MonoBehaviour
{
    public Transform firePoint;
    public float range = 30f;
    public int damage = 10;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            // Scene 뷰에서 1초 동안 레이를 표시합니다.
            Debug.DrawRay(firePoint.position, firePoint.forward * range, Color.red, 1f);

            RaycastHit hit;
            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
            {
                // 의도적으로 Enemy 유무를 검사하지 않습니다. 벽을 맞히면 오류가 납니다.
                hit.collider.GetComponent<Enemy>().hp -= damage;
            }
        }
    }
}
