using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public const float baseSpeed = 6.0f;
    public float nonShiftSpeed=6f;
    // Start is called before the first frame update
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    public float speed = 6f;
    private CharacterController _charController;
    public float gravity = -9.8f;
    public bool jumping = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = nonShiftSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("DDDDDDDDDDDDDDDDDDDDDDDD");
            //transform.Translate(0, 20, 0);
            StartCoroutine(Jump());
            jumping = true;
        }
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        if (!jumping)
        {
            movement.y = gravity;
        }
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
        //transform.Translate(deltaX*Time.deltaTime, 0, deltaZ * Time.deltaTime); 
    }
    private IEnumerator Jump()
    {
        if (!jumping)
        {
            float j = 0;
            for (int i= 0; i< 150; i++)
            {
                transform.Translate(0, 0.075f-j, 0);
                j += 0.001f;
                yield return new WaitForSeconds(0.001f);
            }
            jumping = false;
        }
    }
    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
        nonShiftSpeed = speed;
    }

}
