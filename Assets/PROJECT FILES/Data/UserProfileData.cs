using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserProfileData
{
    public int age; // In years
    public float height; // In Inches (1 foot = 12 inches)
    public float weight; // In KG
    public float[] daily_steps;

    public UserProfileData()
    {
        age = 10;
        height = 10;
        weight = 10;
        daily_steps = new float[14];
    }
}
