using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    [Header("Sway Amount")]
    [Tooltip("How far the camera moves in local space based on mouse position.")]
    public float swayAmount = 0.05f;

    [Tooltip("Maximum offset so the effect stays subtle.")]
    public float maxSway = 0.1f;

    [Header("Smoothness")]
    [Tooltip("How quickly the camera follows the mouse.")]
    public float smoothSpeed = 5f;

    private Vector3 initialLocalPos;

    void Start()
    {
        initialLocalPos = transform.localPosition;
    }

    void Update()
    {
        // Make sure we have a mouse (will be null on some platforms)
        if (Mouse.current == null)
            return;

        // Read mouse position from the new Input System
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // Normalize to 0..1
        float normX = mousePos.x / Screen.width;
        float normY = mousePos.y / Screen.height;

        // Convert to -1..1 (center of screen = 0,0)
        float mouseX = (normX - 0.5f) * 2f;
        float mouseY = (normY - 0.5f) * 2f;

        // Calculate offset
        float offsetX = Mathf.Clamp(mouseX * swayAmount, -maxSway, maxSway);
        float offsetY = Mathf.Clamp(mouseY * swayAmount, -maxSway, maxSway);

        Vector3 targetLocalPos = initialLocalPos + new Vector3(offsetX, offsetY, 0f);

        // Smoothly move toward target
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            targetLocalPos,
            Time.deltaTime * smoothSpeed
        );
    }
}
