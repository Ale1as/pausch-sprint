using System.Collections;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    [Header("Homing")]
    public float speed = 20f;
    public float followDuration = 2f;      // how long it follows the target (seconds)
    public float rotationSpeed = 720f;     // degrees/sec for smooth facing (optional)

    Rigidbody rb;
    Transform target;
    bool isFollowing;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Call this to start homing (e.g. immediately after Instantiate)
    public void Launch(Transform targetTransform)
    {
        target = targetTransform;
        if (target == null)
        {
            Debug.LogWarning("HomingProjectile3D.Launch called with null target.");
            return;
        }
        isFollowing = true;
        StartCoroutine(StopAfterSeconds(followDuration));
    }

    void FixedUpdate()
    {
        if (!isFollowing || target == null) return;

        // Direction toward target
        Vector3 dir = (target.position - transform.position);
        if (dir.sqrMagnitude < 0.0001f)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        dir.Normalize();

        // Option A: set velocity directly (simple)
        rb.linearVelocity = dir * speed;

        // Option B: rotate toward target smoothly (optional)
        Quaternion targetRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime);
    }

    IEnumerator StopAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isFollowing = false;
        rb.linearVelocity = Vector3.zero;
        // Optionally make kinematic so physics won't move it further:
        // rb.isKinematic = true;
    }
}
