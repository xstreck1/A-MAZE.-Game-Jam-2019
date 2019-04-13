using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text height;
    
    private BlockSpawner _blockManager;
    private InputManager _inputManager;

    private List<Block> _spawnedBlocks = new List<Block>();

    private float CurrentHeight { get; } = 0f;

    private float HEIGHT_OFFSET = 5f;

    private float SPAWN_TIMER = 5f;

    private void Start()
    {
        _blockManager = FindObjectOfType<BlockSpawner>();
        _inputManager = FindObjectOfType<InputManager>();
        SpawnBlock(0f);
    }

    private void Update()
    {
        height.text = GetTotalHeight().ToString();
        
        // Let go
        if (!Input.GetKeyDown(KeyCode.Space)) 
            return;
        
        var block = _inputManager.ReleaseBlock();
        _spawnedBlocks.Add(block);
        SpawnBlock(SPAWN_TIMER);
    }

    private void SpawnBlock(float time)
    {
        StartCoroutine(SpawnCoRoutine(time));
    }

    private IEnumerator SpawnCoRoutine(float timer)
    {
        yield return new WaitForSeconds(timer);
        var height = GetTotalHeight();
        var block = _blockManager.GetNewBlock();
        _inputManager.GiveBlock(block, height + HEIGHT_OFFSET);
        yield return null;
    }

    private float GetTotalHeight()
    {
        float totalHeight = 0f;
        
        foreach (var block in _spawnedBlocks)
        {
            totalHeight = Mathf.Max(totalHeight, block.GetHeight());
        }

        return totalHeight;
    }
}