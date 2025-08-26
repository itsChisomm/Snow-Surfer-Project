using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            Debug.Log("You crashed!");
        }
    }
}
