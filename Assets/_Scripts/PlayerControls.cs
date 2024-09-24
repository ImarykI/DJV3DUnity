using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 20f;
    [SerializeField] float xMaxRange = 10f;
    [SerializeField] float yMaxRange = 3f;


    [Header("Rotation")]
    [SerializeField] float positionYawPower = 2f;
    [SerializeField] float positionPitchFactor = -4f;
    [SerializeField] float controlPitchPower = 44f;
    [SerializeField] float controlRollPower = -4f;
    
    void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    private void Update()
    {
        HandleMovemet();
        ProcessRotation();
    }

    void HandleMovemet()
    {
        float horizontalThrow = movement.ReadValue<Vector2>().x;
        float verticalThrow = movement.ReadValue<Vector2>().y;

        float xOffset = horizontalThrow * Time.deltaTime * controlSpeed;
        float yOffset = verticalThrow * Time.deltaTime * controlSpeed;

        float newXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xMaxRange, xMaxRange);
        float newYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yMaxRange, yMaxRange);

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float horizontalThrow = movement.ReadValue<Vector2>().x;
        float verticalThrow = movement.ReadValue<Vector2>().y;

        float pitch = transform.localPosition.y * positionPitchFactor + verticalThrow * controlPitchPower;
        float yaw = transform.localPosition.x * positionYawPower;
        float roll = horizontalThrow * controlRollPower;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}