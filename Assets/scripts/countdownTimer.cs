using UnityEngine;
using TMPro;

public class countdownTimer : MonoBehaviour
{
    [SerializeField]public float startTime = 30f;      // thời gian ban đầu
    private float timeLeft;

    public TextMeshProUGUI timerText;

    private bool isRunning = true;

    void Start()
    {
        timeLeft = startTime;
        UpdateUI();
    }

    void Update()
    {
        if (!isRunning) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            isRunning = false;
            TimeUp();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        timerText.text = "Time left: " + Mathf.Ceil(timeLeft).ToString();
    }

    void TimeUp()
    {
        Debug.Log("Hết giờ!");
        GameManager.instance.Lose();
        // TODO: thua game / reset level
    }
}
