using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonsEnd : MonoBehaviour
{
    [SerializeField] Button playAgainButton;
    [SerializeField] Button menuButton;
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void Start() {
        playAgainButton.onClick.AddListener(Play);
        menuButton.onClick.AddListener(Menu);
        scoreText.text = "You Scored: \n" + scoreKeeper.GetScore().ToString("00000000");
    }

    void Play()
    {
        SceneManager.LoadScene(1);
        scoreKeeper.ResetScore();
    }

    void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
