using UnityEngine;

public class MoveRightV1 : MonoBehaviour
{
    public float speed = 1.0f;
    private bool move = false;

    void Update()
    {
        if (move)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }

    public void StartMove()
    {
        move = true;
    }

    public void StopMove()
    {
        move = false;
    }
}