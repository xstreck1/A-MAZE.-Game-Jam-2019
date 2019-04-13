using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private const float ROTATION_SPEED = 1f;
    private const float MOVEMENT_SPEED = 5f;

    public static RotateCamera Singleton;
    public static float Depth { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        Singleton = this;
        Depth = Mathf.Abs(transform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey((KeyCode.A)))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, Time.deltaTime * 90f * ROTATION_SPEED);
        }

        if (Input.GetKey((KeyCode.D)))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, Time.deltaTime * -90f * ROTATION_SPEED);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Time.deltaTime * MOVEMENT_SPEED;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.deltaTime * MOVEMENT_SPEED;
        }

        var position = transform.position;
        position = new Vector3(position.x, Mathf.Clamp(position.y, 2f, 100f), position.z);
        transform.position = position;
    }
}