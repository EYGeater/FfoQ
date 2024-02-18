using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerTracker : MonoBehaviour
{
    //singleton
    public static PlayerTracker Main;
    public CanvasGroup loseScreen;
    public TMP_Text youSurvivedText;
    public string levelName;
    public WaveManager waveManager;

    public PlayerController player1;
    public PlayerController player2;


    private void Start()
    {
        Main = this;
    }

    public void PlayerDeath()
    {
        if(!player1.alive && !player2.alive)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        youSurvivedText.text = "You survived " + waveManager.GetRound() + " rounds in " + levelName;
        DOTween.To(() => loseScreen.alpha, x => loseScreen.alpha = x, 1f, 3f).SetEase(Ease.InOutCubic);
        StartCoroutine(LoseRoutine());
    }

    private IEnumerator LoseRoutine()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("LevelSelect");
    }
}
