using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private BlockSpawner _blockManager;
    private InputManager _inputManager;

    private List<Block> _spawnedBlocks = new List<Block>();

    private float CurrentHeight { get; } = 0f;

    private float SPAWN_TIMER = 5f;

    private void Start()
    {
        _blockManager = FindObjectOfType<BlockSpawner>();
        _inputManager = FindObjectOfType<InputManager>();
        SpawnBlock(0f);
    }

    private void Update()
    {// Let go
        if (!Input.GetKey(KeyCode.Space)) 
            return;
        
        _inputManager.ReleaseBlock();
        SpawnBlock(SPAWN_TIMER);
    }

    private void SpawnBlock(float time)
    {
        StartCoroutine(SpawnCoRoutine(time));
    }

    private IEnumerator SpawnCoRoutine(float timer)
    {
        yield return new WaitForSeconds(timer);
        var block = _blockManager.GetNewBlock();
        _inputManager.GiveBlock(block);
        yield return null;
    }
}