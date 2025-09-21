using UnityEngine;

public class gameEnd : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject outroimage;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<Movement>().enabled = false;
            FindAnyObjectByType<Camera>().GetComponent<FPScamera>().enabled = false;
            outroimage.SetActive(true);
        }
    }
}
