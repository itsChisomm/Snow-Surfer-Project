using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad;
    [SerializeField] private float restartDelay = 1f;
    [SerializeField] ParticleSystem finishParticles;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            finishParticles.Play();
            Invoke("ReloadScene", restartDelay);
            //SceneManager.LoadScene(0);
            
        }
        
    }

    void ReloadScene()
    {
               SceneManager.LoadScene(sceneIndexToLoad);
    }
}
