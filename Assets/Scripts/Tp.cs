using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    public GameObject Controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(1, 1, 1);
    }
    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            Debug.Log("PlCollision");
            player.Move(0, 7, 10);
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Collision");
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(5);
            //pl.transform.position=new Vector3(0, 7, 10);
        }
    }
}
