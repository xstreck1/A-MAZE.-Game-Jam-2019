using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    private float ROTATION_SPEED = 1f;

    // Update is called once per frame
    void Update()
    {
        // 
        var mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        var screenPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        screenPosition.y = 4f;
        transform.position = screenPosition;
        
        // 
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(transform.position, Camera.main.transform.forward, Time.deltaTime * 90f * ROTATION_SPEED);
        }
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(transform.position, Camera.main.transform.forward, Time.deltaTime * -90f * ROTATION_SPEED);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            enabled = false;
        }
    }
}
