using UnityEngine;
using Assets.Services.Interfaces;

public class Paddle : MonoBehaviour
{

    public float paddleSpeed = 1f;
    private Vector3 playerPos = new Vector3(0, -9.5f, 0);

   
    public IMovePaddleService MovePaddleService { get; set; }


    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);

        //transform.position = MovePaddleService.GetNewPosition(transform.position.x, paddleSpeed);
        transform.position = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);

    }
}
