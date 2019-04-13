using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private BlockSpawner _blockManager;
    private InputManager _inputManager;

    private List<Block> _spawnedBlocks = new List<Block>();

    private float CurrentHeight { get; } = 0f;

    public float SpawnInterval = 3f;

    private void Start()
    {
        _blockManager = FindObjectOfType<BlockSpawner>();
        _inputManager = FindObjectOfType<InputManager>();
        _inputManager.BlockReleased += OnBlockReleased;

        SpawnNewBlock(0f);
    }

    private void OnBlockReleased()
    {
        SpawnNewBlock(SpawnInterval);
    }

    private void SpawnNewBlock(float time)
    {
        StartCoroutine(SpawnCoRoutine(time));
    }

    private IEnumerator SpawnCoRoutine(float timer)
    {
        yield return new WaitForSeconds(timer);

        GiveBlockToInputManager();
    }

    private void GiveBlockToInputManager()
    {
        var block = _blockManager.GetNewBlock();
        _inputManager.GiveBlock(block);
    }
}