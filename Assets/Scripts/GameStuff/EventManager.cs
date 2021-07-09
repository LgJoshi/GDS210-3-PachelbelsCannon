using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartEvent();
    public static event StartEvent GameStarted;
    static public void StartGame () {
        GameStarted();
    }    

    public delegate void BossPhase();
    public static event BossPhase BossPhased;
    static public void StartBoss () {
        BossPhased();
    }

    public delegate void WinEvent();
    public static event WinEvent GameWon;
    static public void WinGame () {
        GameWon();
    }
}
