using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    private void OnEnable()
    {
        EventManager.onPlayerDie += GameOver;
    }

    private void OnDisable()
    {
        EventManager.onPlayerDie -= GameOver;
    }

    private void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
