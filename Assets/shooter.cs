using UnityEngine;

public class shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform target;
    public float fireCooldown = 1f;       // time between shots
    public float maxSightDistance = 20f;  // how far the enemy can see

    private float cooldownTimer;

    void Awake()
    {
        target = FindAnyObjectByType<Duality>().transform; // your player
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (HasLineOfSight() && cooldownTimer <= 0f)
        {
            Fire();
            cooldownTimer = fireCooldown;
        }
    }

    public void Fire()
    {
        GameObject p = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        ProjectileShoot homing = p.GetComponent<ProjectileShoot>();
        if (homing != null) homing.Launch(target);
    }

    bool HasLineOfSight()
    {
        if (target == null) return false;

        Vector3 dir = target.position - transform.position;

        if (dir.magnitude > maxSightDistance) return false; // too far

        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir.normalized, out hit, maxSightDistance))
        {
            // Check if the thing hit is the player
            if (hit.transform == target)
            {
                return true;
            }
        }
        return false;
    }
}
