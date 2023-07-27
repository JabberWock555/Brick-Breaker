using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public Levels[] levels;
    public int currLevel;


    public void onClick(int level_No)
    {
        SoundManager.Instance.Play(SoundEvents.ButtonClick);
        if(levels[level_No - 1].getLevelStatus() == levelStatus.unlocked)
        {
            levels[level_No - 1].setLevelActive();
            GameManager.bricksInLevel = levels[level_No - 1].getBricks();
            GameManager.playing = true;
        }
        else
        {
            Debug.Log("Level Locked");
        }
    }

    private void Start()
    {
        currLevel = 0;
        levels[currLevel].setLevelStatus(levelStatus.unlocked);
        GameManager.bricksInLevel = levels[currLevel].getBricks();
        for (int i = 0; i<levels.Length; i++)
        {
            levels[i].setLevelInactive();
        }
    }

    public void level_Completed()
    {
        if (currLevel <= 2)
        {
            currLevel++;
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i].setLevelInactive();
            }

            levels[currLevel].setLevelStatus(levelStatus.unlocked);
            levels[currLevel].setLevelActive();
            GameManager.bricksInLevel = levels[currLevel].getBricks();
        }
    }

}


