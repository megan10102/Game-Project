using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    [Header("Variables for mouse movement")]
    private float yaw;
    private float pitch;
    public Transform player;

    [Header("Adjustable Attributes")]
    public float cameraDistance = 2.0f;
    public float mouseSensitivity = 10.0f;
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    // Update is called once per frame: Will obtain mouse input and move the camera based on move movement
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        Vector3 playerRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = playerRotation;

        transform.position = player.position - transform.forward * cameraDistance;
    }
}
