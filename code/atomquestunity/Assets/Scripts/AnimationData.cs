using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationData", menuName = "Scriptable Objects/AnimationData", order = 1)]
public class AnimationData : ScriptableObject
{
    public static float targetFrameTime = 0.0167f;
    public int frameOfGap;
    public Sprite[] sprites;
    public bool loop;


}
