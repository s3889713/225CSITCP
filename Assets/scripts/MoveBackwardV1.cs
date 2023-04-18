using UnityEngine;

public class MoveBackwardV1 : MonoBehaviour
{
    public float speed = 1.0f;
    private bool move = false;

    void Update()
    {
        if (move)
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
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