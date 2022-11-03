using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnRaceFinishEventArgs : EventArgs
{
    public Dictionary<GameObject, Score> scores;
}
