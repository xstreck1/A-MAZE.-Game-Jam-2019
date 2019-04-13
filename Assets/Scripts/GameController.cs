using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private BlockSpawner _blockManager;
    private InputManager _inputManager;

    private List<Block> _spawnedBlocks = new List<Block>();

    private float CurrentHeight { get; } = 0f;

    private void Start()
    {
        _blockManager = FindObjectOfType<BlockSpawner>();
        _inputManager = FindObjectOfType<InputManager>();

        var block = _blockManager.GetNewBlock();
        _inputManager.GiveBlock(block);
    }

    private void Update()
    {
    }
}