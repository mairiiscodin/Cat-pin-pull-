using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class levelUI : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    void Start()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        levelText.text = "LEVEL " + level;
    }
}
