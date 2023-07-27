using UnityEngine;

public class Levels : MonoBehaviour
{
    private levelStatus level_Status = levelStatus.locked;
    public int levelNo;
    public GameObject level;
    public int numberofBricks;

    public void setLevelActive()
    {
        level.SetActive(true);
    }
    public void setLevelInactive()
    {
        level.SetActive(false);
    }

    public int getBricks()
    {
        return numberofBricks;
    }

    public int getLevelNo()
    {
        return levelNo;
    }

    public levelStatus getLevelStatus()
    {
        return level_Status;
    }

    public void setLevelStatus(levelStatus levelstatus)
    {
        level_Status = levelstatus;
    }


}

public enum levelStatus
{
    locked,
    unlocked
};
