using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public Vector2 screen = new Vector2(5, 5);
    public float speed = 2;

    private InputController input;
    // Start is called before the first frame update
    void Start()
    {
        input = InputController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = input.PlayerMoveDirection.Value;
        move *= Time.deltaTime * speed;
        Vector3 pos = transform.position;
        pos += move;
        pos = new Vector3(Mathf.Clamp(pos.x, -screen.x / 2, screen.x / 2), 0, Mathf.Clamp(pos.z, -screen.y / 2, screen.y / 2));
        transform.position = pos;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(screen.x, 0, screen.y));
    }
}
