using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Button restartButton;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        restartButton.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void RestartScene()
    {
        Scene scence = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scence.name);
    }

}
