using UnityEngine;

public class Block : MonoBehaviour
{
    public float Weight
    {
        get { return _weight; }
        set { _weight = value; }
    }

    [SerializeField]
    private float _weight;

    public float GetHeight()
    {
        Renderer renderer = GetComponent<Renderer>();
        float height = renderer.bounds.max.y;

        return height;
    }

    private void Update()
    {
        Debug.Log("Height = " + GetHeight().ToString());
    }
}