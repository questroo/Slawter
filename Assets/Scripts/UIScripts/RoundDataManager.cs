using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundDataManager : Singleton<RoundDataManager>
{
    public int kills = 0;
    public int headshots = 0;

    public void ResetData()
    {
        kills = 0;
        headshots = 0;
    }

    public int CalculateScore()
    {
        return (kills * 20) + (headshots * 8);
    }
}