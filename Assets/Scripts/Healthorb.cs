using UnityEngine;

public class Healthorb : MonoBehaviour
{
    public float healthInc;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindAnyObjectByType<Player_health>().current_playerHealth += healthInc;
            Destroy(gameObject);
        }
    }

}
