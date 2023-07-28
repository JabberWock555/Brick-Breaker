using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public static bool playing = false;
    public static int bricksInLevel;
    [SerializeField] private Striker striker;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject levelSelector;
    [SerializeField] private GameObject startScrn;
    [SerializeField] private GameObject pauseScrn;
    [SerializeField] Text scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "Score : " + score; 
        startScrn.SetActive(false);
        pauseScrn.SetActive(true);
        striker.disableStriker();
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score : " + score;

        if(bricksInLevel == 0) {
            levelManager.level_Completed();
        }

        if (playing)
        {
            pauseScrn.SetActive(false);
            levelSelector.SetActive(false);
            striker.enableStriker();
        }
    }

    public void play()
    {
        SoundManager.Instance.Play(SoundEvents.ButtonClick);
        pauseScrn.SetActive(false);
        levelSelector.SetActive(true);
    }

    public void pause()
    {
        SoundManager.Instance.Play(SoundEvents.ButtonClick);
        pauseScrn.SetActive(true);
        playing = false;
        striker.disableStriker();
    }

    public void quit()
    {
        Application.Quit();
    }


}
