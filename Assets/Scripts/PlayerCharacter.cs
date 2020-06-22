using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    private int _health;
    void Start()
    {
        _health = 5;
    }
    
    public void Hurt(int damage)
    {
        //transform.Translate(0, 10, 0);
        _health -= damage;
        Debug.Log("Health: " + _health);
    }
    public void Move(int x,int y, int z)
    {
        Debug.Log("Movement");
        transform.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
