using UnityEngine;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] private GameObject charSelectUI;
    [SerializeField] private GameObject dinoSprite;
    [SerializeField] private GameObject frogSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f; 
    }

    void BeginGame()
    {
        Time.timeScale = 1f;
        charSelectUI.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseDino()
    {
        dinoSprite.SetActive(true); 
        BeginGame();
    }

    public void ChooseFrog()
    {
        frogSprite.SetActive(true);
        BeginGame();
    }
    
}
