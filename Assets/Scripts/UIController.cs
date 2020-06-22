using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;
    // Start is called before the first frame update
    private int _score;
    void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString();
        settingsPopup.Close();
    }
    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);   
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    // Update is called once per frame
    void Update()
    {
        //scoreLabel.text = Time.realtimeSinceStartup.ToString();
    }
    public void OnPointerDown()
    {
        Debug.Log("pointer down");
    }
    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }
    private void OnEnemyHit()
    {
        _score += 1;
        scoreLabel.text = _score.ToString();
    }
}
