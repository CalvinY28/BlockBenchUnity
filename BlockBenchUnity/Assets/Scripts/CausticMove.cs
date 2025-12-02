using UnityEngine;

public class CausticMove : MonoBehaviour
{
    public Vector2 scrollSpeed = new Vector2(0.05f, 0.02f);

    Renderer rend;
    Material mat;
    Vector2 offset;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
    }

    void Update()
    {
        offset += scrollSpeed * Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}
