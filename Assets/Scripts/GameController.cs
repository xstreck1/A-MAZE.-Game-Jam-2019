using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private BlockManager _blockManager;

    private List<Block> _spawnedBlocks = new List<Block>();

    private void Start()
    {
        _blockManager = FindObjectOfType<BlockManager>();
    }

    private void Update()
    {
    }
}