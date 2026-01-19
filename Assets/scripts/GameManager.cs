using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject winPanel;
    public GameObject losePanel;

    void Awake(){
        instance = this;
    }

    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void Win()
    {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
    }

    public void Lose()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }
}
