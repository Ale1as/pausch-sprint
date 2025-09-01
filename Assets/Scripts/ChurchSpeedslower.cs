using UnityEngine;

public class ChurchSpeedslower : MonoBehaviour
{
    public Movement movement;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            movement.walkSpeed = 5f;
            movement.sprintSpeed = 5f;
            movement.jumpForce = 0f;
        }
    }
}
