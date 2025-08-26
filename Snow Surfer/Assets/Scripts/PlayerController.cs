using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f; // Amount of torque to apply for rotation
    [SerializeField] private float baseSpeed = 15f; // Base speed for boosting
    [SerializeField] private float boostSpeed = 20f; // Multiplier for boosting speed
    [SerializeField] ParticleSystem powerupParticle;
    [SerializeField] ScoreManager scoreManager;

    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    SurfaceEffector2D surfaceEffector2D;
    

    bool canControlPlayer = true;
    float previousRotation;
    float totalRotation;
    int activePowerupCount;


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
            totalRotation = 0; // Reset total rotation after counting a flip
            scoreManager.AddScore(100); // Add 100 points for each flip
        }


        previousRotation = currentRotation; // Store the current rotation for the next frame
    }
     
    public void DisableControls() 
    {       
        canControlPlayer = false;
    }

    public void ActivatePowerup(PowerupSO powerup)
    {
        powerupParticle.Play();
        activePowerupCount += 1;

        if (powerup.GetPowerupType() == "speed")
        {
            baseSpeed += powerup.GetValueChange();
            boostSpeed += powerup.GetValueChange();
        }
        else if (powerup.GetPowerupType() == "torque")
        {
            torqueAmount += powerup.GetValueChange();

        }
    }

    public void DeactivatePowerup(PowerupSO powerup)
    {
        activePowerupCount -= 1;
        if(activePowerupCount == 0)
        {
            powerupParticle.Stop();
        }

        if (powerup.GetPowerupType() == "speed")
        {
            baseSpeed -= powerup.GetValueChange();
            boostSpeed -= powerup.GetValueChange();
        }
        else if (powerup.GetPowerupType() == "torque")
        {
            torqueAmount -= powerup.GetValueChange();

        }
    }
}
