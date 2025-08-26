using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "PowerupSO")]
public class PowerupSO : ScriptableObject
{
    [SerializeField] private string powerupType;
    [SerializeField] private float valueChange;
    [SerializeField] private float time;

    public string GetPowerupType() 
    { 
        return powerupType; 
    }

    public float GetValueChange() 
    { 
        return valueChange;
    }

    public float GetTime() 
    { 
        return time;
    }
}
