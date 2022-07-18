using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public RectTransform crosshair;
    public Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.mousePosition.x + offset.x;
        float y = Input.mousePosition.y + offset.y;
        crosshair.gameObject.transform.position = new Vector2(x,y);
    }
}
