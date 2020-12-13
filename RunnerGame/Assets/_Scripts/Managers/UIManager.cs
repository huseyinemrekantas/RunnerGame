using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
//using ElephantSDK;
//using GameAnalyticsSDK;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject instructive;
    [SerializeField] private ParticleSystem winParticle;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Animator popupTextAnimator;
    [SerializeField] private Animator popupAnimator;
    [SerializeField] private Sprite[] perfectPopups;
    [SerializeField] private Text levelText;

    private bool youWin;

    private void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    private void Awake()
    {
        MakeInstance();
        //GameAnalytics.Initialize();
        levelText.text = "LEVEL " + (PlayerPrefs.GetInt("Level") + 1).ToString();
        if (PlayerPrefs.GetInt("Level") == 0)
        {
            instructive.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        winParticle = CameraSmooth.instance.transform.GetChild(0).GetComponent<ParticleSystem>();
        //Elephant.LevelStarted(PlayerPrefs.GetInt("Level") + 1);
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, (PlayerPrefs.GetInt("Level") + 1).ToString());
    }

    public void PopupOpen()
    {
        popupAnimator.GetComponent<Image>().sprite = perfectPopups[UnityEngine.Random.Range(0, perfectPopups.Length)];
        popupAnimator.GetComponent<Image>().SetNativeSize();
        popupAnimator.SetTrigger("Action");
    }

    public void PopupTextOpen(string text)
    {
        popupTextAnimator.transform.GetChild(0).GetComponent<Text>().text = text;
        popupTextAnimator.SetTrigger("PopupText");
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        //Elephant.LevelCompleted(PlayerPrefs.GetInt("Level"));
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, PlayerPrefs.GetInt("Level").ToString());
        SceneManager.LoadScene(1);
    }


    public void GameOver()
    {
        //if (GameManager.instance.endGame)
        //{
        //    return;
        //}
        //Elephant.LevelFailed(PlayerPrefs.GetInt("Level") + 1);
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, (PlayerPrefs.GetInt("Level") + 1).ToString());
        //GameManager.instance.endGame = true;
        Wait(1.5f, () =>
        {
            startPanel.SetActive(false);
            losePanel.SetActive(true);
        });

    }

    public void YouWin()
    {
        if (youWin)
        {
            return;
        }
        youWin = true;
        winParticle.Play();
        Wait(2f, () =>
        {
            startPanel.SetActive(false);
            winPanel.SetActive(true);
        });
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Wait(float second, Action action)
    {
        StartCoroutine(WaitCoroutune(second, action));
    }
    private IEnumerator WaitCoroutune(float second, Action action)
    {
        yield return new WaitForSeconds(second);
        if (action != null)
        {
            action.Invoke();
        }
        yield return new WaitForSeconds(second);
    }
}
