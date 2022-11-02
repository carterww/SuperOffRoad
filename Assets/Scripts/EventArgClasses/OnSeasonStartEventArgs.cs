using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSeasonStartEventArgs : EventArgs
{
    public int numOfPlayers
    {
        get { return numOfPlayers; }
        set
        {
            if (value > 3) 
            {
                numOfPlayers = 3;
            }
            else if (value < 1)
            {
                numOfPlayers = 1;
            }
            else
            {
                numOfPlayers = value;
            }
        }
    }
}
