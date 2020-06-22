using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public const float baseSpeed = 3.0f;
    public bool _alive;
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    //[SerializeField] private SceneController sceneController;
    [SerializeField] private GameObject fireballprefab;
    //[SerializeField] private GameObject fireeffectprefab;
    private GameObject _fireball;
    //private GameObject _fireeffect;
    void Start()
    {
        _alive = true;
        //speed = 3f;
    }
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.SphereCast(ray,0.75f,out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if(hitObject.GetComponent<PlayerCharacter>())
            {
                if (_fireball == null&&_alive)
                {
                    //_fireeffect = Instantiate(fireeffectprefab) as GameObject;
                    //_fireeffect.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    //_fireeffect.transform.rotation = transform.rotation;

                    _fireball = Instantiate(fireballprefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
