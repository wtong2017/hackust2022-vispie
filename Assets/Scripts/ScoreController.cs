using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int Score { get; private set; }

    public void AddPoints(int points) {
        Score += points;
    }

    public void DeductPoints(int points) {
        Score -= points;
    }

    public void Initialize(int initPoints) {
        Score = initPoints;
    }
}
