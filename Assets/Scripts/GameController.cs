using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private BlockSpawner _blockManager;

    private List<Block> _spawnedBlocks = new List<Block>();

    private float CurrentHeight { get; } = 0f;

    private void Start()
    {
        _blockManager = FindObjectOfType<BlockSpawner>();
    }

    private void Update()
    {
    }
}