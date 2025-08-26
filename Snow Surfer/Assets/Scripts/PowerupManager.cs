using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private PowerupSO powerup;

    PlayerController player;
    
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            player.ActivatePowerup(powerup);
        }
    }
}
