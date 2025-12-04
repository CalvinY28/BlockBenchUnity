using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    [Header("Rotation Amount")]
    [Tooltip("How much the camera can rotate in degrees.")]
    public float rotationAmount = 5f;

    [Header("Smoothness")]
    public float smoothSpeed = 5f;

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        // Read mouse position
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // Normalize to 0–1
        float normX = mousePos.x / Screen.width;
        float normY = mousePos.y / Screen.height;

        // Convert to -1 and 1 (center = 0)
        float mouseX = (normX - 0.5f) * 2f;
        float mouseY = (normY - 0.5f) * 2f;

        // Calculate target rotation
        // Mouse X -> look left/right (Yaw)
        // Mouse Y -> look up/down (Pitch)
        float targetYaw = -mouseX * rotationAmount;
        float targetPitch = mouseY * rotationAmount;

        Quaternion targetRot = initialRotation * Quaternion.Euler(targetPitch, targetYaw, 0f);

        // Smooth rotation
        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            targetRot,
            Time.deltaTime * smoothSpeed
        );
    }
}
