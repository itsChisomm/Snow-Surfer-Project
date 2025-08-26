using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f; // Amount of torque to apply for rotation
    [SerializeField] private float baseSpeed = 15f; // Base speed for boosting
    [SerializeField] private float boostSpeed = 20f; // Multiplier for boosting speed

    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    SurfaceEffector2D surfaceEffector2D;

    Vector2 moveVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        RotatePlayer();
        BoostPlayer();

    }

    void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>(); // Read the value of the "Move" action
        
        if (moveVector.x < 0)
        {
            myRigidbody2D.AddTorque(torqueAmount); // Apply torque to rotate the player left
        }

        else if (moveVector.x > 0)

        {
            myRigidbody2D.AddTorque(-torqueAmount); // Apply torque in the opposite direction
        }
    }

    void BoostPlayer()
    {
        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed; // Increase the speed of the surface effector to boost
        }
        else 
        {
            surfaceEffector2D.speed = baseSpeed; // Reset to base speed when not boosting
        }
    }
}
