using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player_health>().current_playerHealth -= 2f;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Destroy(gameObject, 1.5f);
    }
}
