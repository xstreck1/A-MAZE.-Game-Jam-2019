using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float ROTATION_SPEED = 1f;

    Block CurrentBlock { get; set; }

    public void GiveBlock(Block block)
    {
        CurrentBlock = block;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!CurrentBlock)
            return;

        // Movement
        var mousePosition = Input.mousePosition;
        mousePosition.z = RotateCamera.Depth;
        var screenPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        screenPosition.y = 4f;
        transform.position = screenPosition;

        // Rotation
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(transform.position, RotateCamera.Singleton.transform.forward,
                Time.deltaTime * 90f * ROTATION_SPEED);
        }

        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(transform.position, RotateCamera.Singleton.transform.forward,
                Time.deltaTime * -90f * ROTATION_SPEED);
        }

        // Let go
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            CurrentBlock = null;
        }
    }
}