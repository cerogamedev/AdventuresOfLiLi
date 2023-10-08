using UnityEngine;

public class PlayerController : TimeControlled
{
    float moveSpeed = 10f;
    float jumpPower = 40f;
    public override void TimeUpdate()
    {
        Vector2 pos = transform.position;

        pos.y += velocity.y * Time.deltaTime;
        velocity.y += TimeController.gravity * Time.deltaTime;

        if (pos.y <1)
        {
            pos.y = 1;
            velocity.y = 1;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            velocity.y = jumpPower;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += moveSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }

}
