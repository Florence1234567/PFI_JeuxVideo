using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerViewComponent : MonoBehaviour
{
    [SerializeField] Transform player;
    float cameraRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 delta = Mouse.current.delta.ReadValue() * Time.deltaTime * 75;

        cameraRotation -= delta.y;
        cameraRotation = Mathf.Clamp(cameraRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(cameraRotation, 0, 0);

        player.Rotate(Vector3.up * delta.x);
    }
}
