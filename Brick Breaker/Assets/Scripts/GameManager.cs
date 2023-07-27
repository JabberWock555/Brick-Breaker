using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public static bool playing = false;
    [SerializeField] private GameObject level_1;
    [SerializeField] private GameObject level_2;
    [SerializeField] private GameObject level_3;
    [SerializeField] private GameObject levelSelector;
    [SerializeField] private GameObject startScrn;
    [SerializeField] private GameObject pauseScrn;
    [SerializeField] Text scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "Score : " + score; 
        startScrn.SetActive(false);
        level_1.SetActive(false);
        level_2.SetActive(false);
        level_3.SetActive(false);
        pauseScrn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score : " + score;
    }

    public void play()
    {
        pauseScrn.SetActive(false);
        levelSelector.SetActive(true);
    }

    public void pause()
    {
        pauseScrn.SetActive(true);
        playing = false;
    }


}
