using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemyPrefab;
    public const float baseSpeed = 3.0f;
    public float speed = 3.0f;
    private GameObject _enemy;
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(0, 2f, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
            WanderingAI enemy = _enemy.GetComponent<WanderingAI>();
            if (enemy != null)
            {
                enemy.speed = speed;
            }
        }
    }
}
