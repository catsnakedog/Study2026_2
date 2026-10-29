using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastEffectsShooter : MonoBehaviour
{
    public Transform firePoint;
    public float range = 30f;
    public int damage = 10;
    public ParticleSystem hitParticlePrefab;
    public float cooldown = 0.5f;

    float nextFireTime;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.spaceKey.wasPressedThisFrame && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + cooldown;
            Debug.DrawRay(firePoint.position, firePoint.forward * range, Color.red, 1f);

            RaycastHit hit;
            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range)
                && hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>().hp -= damage;

                ParticleSystem effect = Instantiate(hitParticlePrefab,
                    hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(effect.gameObject, 2f);
            }
        }
    }
}
