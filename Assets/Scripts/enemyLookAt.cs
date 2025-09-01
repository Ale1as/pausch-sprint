using System.Runtime.InteropServices;
using UnityEngine;

public class enemyLookAt : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float yRotation;

    void Awake()
    {
        _mainCamera = GameObject.FindAnyObjectByType<Camera>();
    }
    void LateUpdate()
    {
        Vector3 cameraPosition = _mainCamera.transform.position;

        cameraPosition.y = transform.position.y;

        transform.LookAt(cameraPosition);

        transform.Rotate(0f, yRotation, 0f);
    }
}
