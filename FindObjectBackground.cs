using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObjectBackground : MonoBehaviour
{
    private GameObject light_Drag;

    Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        light_Drag = GameObject.Find("Light_Drag");
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
                light_Drag.transform.position = newPosition;
            }
        }
    }



}
