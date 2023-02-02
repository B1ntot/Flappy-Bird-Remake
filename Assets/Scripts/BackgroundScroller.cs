using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Placed on a plane object
    // Image wrap mode is set to repeat
    // Rotate (90, -180 ,0) to make 3D plane face the camera in a 2D game
    [SerializeField] float scrollSpeed = 0.5f;
    float offset;
    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

    public void StopScroll()
    {
        scrollSpeed = 0.0f;
    }
}
