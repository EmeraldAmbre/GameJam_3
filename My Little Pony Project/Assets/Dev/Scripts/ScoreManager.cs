using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    [SerializeField] TextMeshPro _scoreText1;
    [SerializeField] TextMeshPro _scoreText2;
    [SerializeField] TextMeshPro _scoreText3;
    void Start()
    {
        int _score = PlayerPrefs.GetInt("Score");
        _scoreText1.text = _score.ToString();
        _scoreText2.text = _score.ToString();
        _scoreText3.text = _score.ToString();
    }
}
