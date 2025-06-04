using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float verticalSpeed = 4f;
    public float acceleration = 5f;

    public BalloonInflate leftBalloon;
    public BalloonInflate rightBalloon;

    private Vector3 currentVelocity = Vector3.zero;

    void Update()
    {
        // inputs
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow)) input.x = -1;
        if (Input.GetKey(KeyCode.RightArrow)) input.x = 1;
        if (Input.GetKey(KeyCode.UpArrow)) input.y = 1;
        if (Input.GetKey(KeyCode.DownArrow)) input.y = -1;

        input = input.normalized;

        // atrums
        Vector3 targetVelocity = new Vector3(input.x * moveSpeed, input.y * verticalSpeed, 0f);
        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, Time.deltaTime * acceleration);
        transform.position += currentVelocity * Time.deltaTime;

        // balonu pushana
        float leftInflate = Mathf.Clamp01((1 - input.x) / 2f + input.y);
        float rightInflate = Mathf.Clamp01((1 + input.x) / 2f + input.y);

        if (leftBalloon != null) leftBalloon.Inflate(leftInflate);
        if (rightBalloon != null) rightBalloon.Inflate(rightInflate);
    }
}
