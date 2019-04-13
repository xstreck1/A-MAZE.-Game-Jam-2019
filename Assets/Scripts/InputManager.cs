using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera fakeCamera;

    public delegate void BlockReleasedEventHandler(Block block);

    public event BlockReleasedEventHandler BlockReleased;

    private float ROTATION_SPEED = 1f;
    private float currentHeight = 10f;
    private GameController _gameController;

    public Block CurrentBlock { get; set; }

    public void GiveBlock(Block block, float newHeight)
    {
        CurrentBlock = block;
        currentHeight = newHeight;
    }

    public void ReleaseBlock()
    {
        CurrentBlock.GetComponent<Rigidbody>().isKinematic = false;
        BlockReleased?.Invoke(CurrentBlock);
        CurrentBlock = null;
    }

    private void Start()
    {
        _gameController = GameObject.FindObjectOfType<GameController>();
    }

    private void Update()
    {
        if (!CurrentBlock || _gameController.GameIsOver)
            return;

        var blockTransform = CurrentBlock.transform;

        // Movement
        var mousePosition = Input.mousePosition;
        mousePosition.z = RotateCamera.Depth;
        var screenPosition = fakeCamera.ScreenToWorldPoint(mousePosition);
        screenPosition.y = currentHeight;
        blockTransform.position = screenPosition;

        // Rotation
        if (Input.GetMouseButton(0))
        {
            blockTransform.RotateAround(blockTransform.position, fakeCamera.transform.forward,
                Time.deltaTime * 90f * ROTATION_SPEED);
        }

        if (Input.GetMouseButton(1))
        {
            blockTransform.RotateAround(blockTransform.position, fakeCamera.transform.forward,
                Time.deltaTime * -90f * ROTATION_SPEED);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            ReleaseBlock();
        }
    }
}