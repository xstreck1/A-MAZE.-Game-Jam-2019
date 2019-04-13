using UnityEngine;

public class Block : MonoBehaviour
{
    public float Weight
    {
        get => _weight;
        set => _weight = value;
    }
    
    [SerializeField]
    private float _weight;

    public Vector3 Center { get; private set; }

    private Renderer _renderer;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Center = _renderer.bounds.center;
    }

    public float GetHeight() => _renderer.bounds.max.y;
}