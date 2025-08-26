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

    bool canControlPlayer = true;
    float previousRotation;
    float totalRotation;
    int flipCount = 0;

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
        if (canControlPlayer)
        {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();
        }

        

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

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation); // Calculate the change in rotation since the last frame

        if (totalRotation > 340 || totalRotation < -340)
        {
            flipCount += 1;
            totalRotation = 0; // Reset total rotation after counting a flip
            print("Flips: " + flipCount);
        }


        previousRotation = currentRotation; // Store the current rotation for the next frame
    }
     
    public void DisableControls() 
    {       
        canControlPlayer = false;
    }
}
