using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StageData
{
    public List<Stage> stages;
}

[Serializable]
public class Stage
{
    public int stageID;
    public string stageName;
    public List<Point> points;
}

[Serializable]
public class Point
{
    public int id;
    public Position position;
    public Instrument instrument;
}

[Serializable]
public class Position
{
    public float x;
    public float y;
    public float z;
}

[Serializable]
public class Rotation
{
    public float x;
    public float y;
    public float z;
}

[Serializable]
public class Instrument
{
    public string name;
    public string pitch;
    public Rotation rotation;
    public string BouncePower;
    public string SEName;
} 