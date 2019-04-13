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

    public void ReleaseBlock()
    {
        if (!CurrentBlock) 
            return;
        CurrentBlock.GetComponent<Rigidbody>().isKinematic = false;
        CurrentBlock = null;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!CurrentBlock)
            return;

        var blockTransform = CurrentBlock.transform;

        // Movement
        var mousePosition = Input.mousePosition;
        mousePosition.z = RotateCamera.Depth;
        var screenPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        screenPosition.y = 10f;
        blockTransform.position = screenPosition;

        // Rotation
        if (Input.GetMouseButton(0))
        {
            blockTransform.RotateAround(blockTransform.position, RotateCamera.Singleton.transform.forward,
                Time.deltaTime * 90f * ROTATION_SPEED);
        }

        if (Input.GetMouseButton(1))
        {
            blockTransform.RotateAround(blockTransform.position, RotateCamera.Singleton.transform.forward,
                Time.deltaTime * -90f * ROTATION_SPEED);
        }
    }
}