using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text heightText;
    [SerializeField] private Text GameOverText;
    [SerializeField] private BoxCollider WaterCollider;

    private BlockSpawner _blockManager;
    private InputManager _inputManager;

    private List<Block> _spawnedBlocks = new List<Block>();

    [SerializeField] private float HEIGHT_OFFSET = 5f;

    public float SpawnInterval = 3f;

    public bool GameIsOver = false;

    private void Start()
    {
        _blockManager = FindObjectOfType<BlockSpawner>();
        _inputManager = FindObjectOfType<InputManager>();
        _inputManager.BlockReleased += OnBlockReleased;

        SpawnNewBlock(0f);
    }

    private void Update()
    {
        heightText.text = GetTotalHeight().ToString("0.00");
    }

    private void OnBlockReleased(Block block)
    {
        _spawnedBlocks.Add(block);
        SpawnNewBlock(SpawnInterval);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GameOver");
        GameIsOver = true;
        DisplayGameOverText();
    }

    private void DisplayGameOverText()
    {
        GameOverText.text = "Your tower reached a height of " + GetTotalHeight().ToString("0.00");
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
        if (GameIsOver) { return; }

        var block = _blockManager.GetNewBlock();
        _inputManager.GiveBlock(block, GetTotalHeight() + HEIGHT_OFFSET);
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