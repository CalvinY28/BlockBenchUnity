using UnityEngine;

public class GodRayMove : MonoBehaviour
{
    public float amplitude = 2f;
    public float speed = 0.3f;

    Vector3 baseScale;

    void Start() => baseScale = transform.localScale;

    void Update()
    {
        float s = 1f + Mathf.Sin(Time.time * speed) * (amplitude * 0.01f);
        transform.localScale = new Vector3(baseScale.x * s, baseScale.y, baseScale.z * s);
    }
}
