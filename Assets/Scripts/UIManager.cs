using UnityEngine;
using System.Collections;
using System;

public class UIManager
{
    private static UIManager uimInstance;
    private int score;
    private int timer;
    private int scene;
    private int lastScene;
    private float startTime;

    private UIManager()
    {
        Debug.Log("Create Instance");
        score = 0;
        scene = 0;
        lastScene = scene;
    }

    public static UIManager getInstance
    {
        get
        {
            if (uimInstance == null) { uimInstance = new UIManager(); }
            return uimInstance;
        }
    }

    public void setTime()
    {
        startTime = Time.time;
    }

    internal void Restart()
    {
        score = 0;
        lastScene = 0;
    }

    public int getCountTime()
    {
        return 60 + (int)(startTime - Time.time);
    }

    public double getRawCountTime
    {
        get { return 60.0 + startTime - Time.time; }
    }

    public int Catcher
    {
        set { score += value; }
        get { return score; }
    }

    public int SceneChangeListener
    {
        set { scene = value; }
        get { return scene; }
    }

}