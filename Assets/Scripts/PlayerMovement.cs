using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 10.0f;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movePlayer(input);
    }

    void movePlayer(Vector2 input)
    {
        if (input.normalized != Vector2.zero)
        {
            playerController.Move(transform.forward * moveSpeed * Time.deltaTime);
            float targetAngle = Mathf.Rad2Deg * Mathf.Atan2(input.x, input.y) + camera.eulerAngles.y;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }
    }
}
