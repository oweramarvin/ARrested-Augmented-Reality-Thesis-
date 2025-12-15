using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDrag : MonoBehaviour
{
    private GameObject thingsLight;
    Quaternion pos;

    Vector3 startPoint;

    void Start()
    {
        thingsLight = GameObject.Find("ThingsLight");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        transform.position = newPosition;

        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;
        pos.z = 0;
        transform.rotation = pos;
        float dist = Vector2.Distance(startPoint, newPosition);
    }

    void OnMouseDown()
    {
        


    }

}
