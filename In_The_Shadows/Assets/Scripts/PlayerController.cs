using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private             InputAction         move;
    private             Camera              mainCamera;
    private             CharacterController controller;
    private             Vector3             velocity;

    [SerializeField]    float         speed = 5f;
    [SerializeField]    Animator      animator;


    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        mainCamera = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    void Update()
	{
		if (!GameManager.instance.isInMenu)
			DoMovement();
    }

    private void DoMovement()
    {
        Vector2 movementValue = move.ReadValue<Vector2>();

        Vector3 moveDirection = new Vector3(movementValue.x, 0f, 0f);
        if (moveDirection.x > 0)
        {
            
            animator.SetBool("moving_left", true);
            animator.SetBool("moving_right", false);
        }
        else if (moveDirection.x < 0)
        {
            animator.SetBool("moving_right", true);
            animator.SetBool("moving_left", false);
        }
        else
        {
            animator.SetBool("moving_left", false);
            animator.SetBool("moving_right", false);
        }//set right or left animations when moving 


        Vector3 previousPosition = transform.position;

        controller.Move((moveDirection * speed + velocity) * Time.deltaTime);

        Vector3 actualMovement = transform.position - previousPosition;

        mainCamera.transform.position += new Vector3(actualMovement.x, 0f, 0f);
    }
}
