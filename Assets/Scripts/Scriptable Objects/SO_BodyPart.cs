﻿using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Part", menuName = "Body Part")]
public class SO_BodyPart : ScriptableObject
{
    // ~~ 1. Holds details about a body part's animations

    // Body Part Details
    public string bodyPartName;
    public int bodyPartAnimationID;

    // List Containing All Body Part Animations
    public List<AnimationClip> allBodyPartAnimations = new List<AnimationClip>();
}