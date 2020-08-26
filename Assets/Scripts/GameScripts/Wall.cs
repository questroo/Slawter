using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private bool isOccupied = false;
    public bool IsOccupied
    {
        get
        {
            return isOccupied;
        }
        set
        {
            isOccupied = value;
        }
    }
}
