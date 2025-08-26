using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad;
    [SerializeField] private float restartDelay = 1f;
    [SerializeField] ParticleSystem crashParticles;

    PlayerController playerController;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            playerController.DisableControls();
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

