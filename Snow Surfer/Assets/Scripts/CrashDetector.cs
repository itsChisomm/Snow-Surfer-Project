using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad;
    [SerializeField] private float restartDelay = 1f;
    [SerializeField] ParticleSystem crashParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            crashParticles.Play();
            Invoke("ReloadScene", restartDelay);
            //SceneManager.LoadScene(0);
        }
    }
     void ReloadScene()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }

}

