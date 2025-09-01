using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;

    public void Finish(bool isWin)
    {
        gameObject.SetActive(true);
        if (isWin)
        {
            _title.text = "Win";
        }
        else
        {
            _title.text = "Lose";
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}