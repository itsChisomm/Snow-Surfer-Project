using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f; // Amount of torque to apply for rotation
    InputAction moveAction;
    Rigidbody2D myRigidbody2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>(); // Read the value of the "Move" action
        print(moveVector); // Print the move vector to the console
        if (moveVector.x < 0)
        {
            myRigidbody2D.AddTorque(torqueAmount); // Apply torque to rotate the player left
        } 
        
        else if (moveVector.x > 0) 
        
        {
            myRigidbody2D.AddTorque(-torqueAmount); // Apply torque in the opposite direction
        }  

        
    }
}
