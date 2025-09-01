using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Camera cam;          // Leave empty to use Camera.main
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private LayerMask hitMask = ~0;  // Default: everything
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject soulSnatcher;

    public Duality dualScript;

    public bool haskey = false;

    void Awake()
    {
        if (cam == null) cam = Camera.main;
        if (cam == null) Debug.LogWarning("MouseRaycastShooter: No Camera assigned and no Camera.main found.");
    }
    void Update()
    {

    }
    void LateUpdate()
    {

        if (dualScript.switched)
        {
            maxDistance = 5f;
        }
        else
        {
            maxDistance = 25f;
        }
        // Left mouse click
        if (Input.GetMouseButton(0))
        {
 
            if (cam == null) return;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Visualize the ray for a short time
            Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.white, 5f);

            if (Physics.Raycast(ray, out hit, maxDistance, hitMask, QueryTriggerInteraction.Ignore))
            {
                soulSnatcher.SetActive(true);
                Debug.Log($"Hit: {hit.collider.gameObject.name} at {hit.point}");
                if (hit.collider.gameObject == null)
                {
                    Debug.LogWarning("object missing");
                }
                if (Player.GetComponent<Duality>().switched == false)
                {
                    hit.collider.gameObject.GetComponent<enemyHealth>().Health -= 2f * Time.deltaTime;
                    soulSnatcher.GetComponent<drawLine>().soulLine(hit.point);
                }

                if (hit.collider.gameObject.name == "key")
                {
                    haskey = true;
                    FindAnyObjectByType<FoundKey>().TriggerDialogue();
                    Destroy(hit.collider.gameObject);
                }
                if (haskey && hit.collider.gameObject.name == "Door_1A")
                {
                    Destroy(hit.collider.gameObject, 2f);
                }
                if (haskey && hit.collider.gameObject.name == "Exorcism")
                {
                    Destroy(hit.collider.gameObject);
                    Player.transform.position = hit.collider.gameObject.transform.position;
                    Player.GetComponent<Movement>().enabled = false;
                    FindAnyObjectByType<Camera>().GetComponent<FPScamera>().enabled = false;
                    Player.transform.eulerAngles = new Vector3(0, 0, 0);
                    FindAnyObjectByType<StartExorcism>().TriggerDialogue();
                }
            }
            else
            {
                soulSnatcher.SetActive(false);
                Debug.Log("No Hit");
            }
        }
        else
        {
            soulSnatcher.SetActive(false);
        }
        
    }

}
