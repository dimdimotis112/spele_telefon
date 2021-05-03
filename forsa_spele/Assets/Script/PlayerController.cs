using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 dir;
    [SerializeField] public float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
	public float maxSpeed;

    private int lineToMove = 1;
    public float lineDistance = 4;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
		if (speed < maxSpeed)
		speed += 0.2f * Time.deltaTime;
		
        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
                lineToMove--;
        }

        if (SwipeController.swipeUp)
        {
            if (controller.isGrounded)
                Jump();
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;

        transform.position = Vector3.Lerp(transform.position, targetPosition, 50 * Time.deltaTime);
		controller.center = controller.center;
    }

    private void Jump()
    {
        dir.y = jumpForce;
    }

    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }
	
	private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.GameOver = true;
        }
    }
	
}