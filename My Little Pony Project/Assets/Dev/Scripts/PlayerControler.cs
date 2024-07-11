using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerControler : MonoBehaviour {

    [SerializeField] Rigidbody2D _playerRigidbody;
    [SerializeField] SpriteRenderer _playerSpriteRenderer;
    [SerializeField] BoxCollider2D _playerCollider;
    [SerializeField] TextMeshProUGUI _scoreText1;
    [SerializeField] TextMeshProUGUI _scoreText2;
    [SerializeField] Transform _playerObject;

    [SerializeField] private TransitionSettings _transitionSettings;
    [SerializeField] private float m_transitionDelay;
    [SerializeField] private string m_sceneToLoadName;

    public int _score;
    public bool _isAlive;

    void Start() { 
        _isAlive = true;
    }
    
    void Update() {
        if (_isAlive) {
            _score += 1;
            _scoreText1.text = _score.ToString();
            _scoreText2.text = _score.ToString();
        }

        if (_playerObject.position.y < -1)
        {
            _isAlive = false;
            ScoreScreen();
        }
    }

    void ScoreScreen()
    {
        PlayerPrefs.SetInt("Score", _score);
        PlayerPrefs.Save();
        TransitionManager.Instance().Transition(m_sceneToLoadName, _transitionSettings, m_transitionDelay);
    }

}
