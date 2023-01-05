using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsMain : MonoBehaviour
{
    [Header("Action")]
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;

    [Header("SpaceShip")]
    [SerializeField] GameObject shipObjects;
    [SerializeField] Button shipRightButton;
    [SerializeField] Button shipLeftButton;
    [SerializeField] List<Sprite> spaceShips;

    [Header("Music")]
    [SerializeField] Button musicButton;
    [SerializeField] Sprite audioOn;
    [SerializeField] Sprite audioOff;

    ScoreKeeper scoreKeeper;
    AudioPlayer audioPlayer;
    Image musicImage;
    Image shipImage;
    int ship = 0;

    void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start() {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
        musicButton.onClick.AddListener(MusicOnOff);
        shipLeftButton.onClick.AddListener(LeftButton);
        shipRightButton.onClick.AddListener(RightButton);
        musicImage = musicButton.transform.Find("Image").GetComponent<Image>();
        shipImage = shipObjects.transform.Find("SpaceShip Image").GetComponent<Image>();
    }

    void Play()
    {
        SceneManager.LoadScene(1);
    }

    void Quit()
    {
        Application.Quit();
    }

    void MusicOnOff()
    {
        audioPlayer.MusicOnOff();
        if (musicImage.sprite == audioOff) {
            musicImage.sprite = audioOn;
        } else {
            musicImage.sprite = audioOff;
        }
    }

    void LeftButton(){
        ChangeShip(-1);
    }

    void RightButton(){
        ChangeShip(1);
    }

    void ChangeShip(int direction){
        ship += direction;
        if (ship < 0) {
            ship = 4;
        } else if (ship > 3) {
            ship = 0;
        }
        shipImage.sprite = spaceShips[ship];
        audioPlayer.ChangeShip(spaceShips[ship]);
    }
}
