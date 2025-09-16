using UnityEditor;
using UnityEngine;
using SmoothShakeFree;

public class enemyHealth : MonoBehaviour
{
    public SmoothShake cameraShake;
    public ParticleSystem blood;
    public Healthorb healthorb;
    public GameObject shooterGameObject;
    public float Health;

    // Update is called once per frame

    void Awake()
    {
        cameraShake = GameObject.FindAnyObjectByType<Camera>().GetComponent<SmoothShake>();
    }
    void Update()
    {
        blood.transform.position = transform.position;
        if (Health <= 0)
        {
            blood.Play();
            cameraShake.StartShake();
            Destroy(gameObject);
            Destroy(shooterGameObject);
            FindAnyObjectByType<Player_health>().killCount += 1;
        }

    }
}
