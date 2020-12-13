using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    static GameObject panel;

    private void Start()
    {
        panel = transform.GetChild(0).gameObject;
    }
    public static void gameOverTrue()
    {
        panel.SetActive(true);
    }

    public void restartGame(string scene)
    {
        GameController.Instance.GameOver = false;
        panel.SetActive(false);
        SceneManager.LoadScene(scene);
        GameController.Instance.doorZ = 9;
        GameController.Instance.deleteChildCount = 0;
    }

}
