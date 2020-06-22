using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public bool _alive;
    public void SetAlive(bool alive)
    {
        _alive = alive;
        //Debug.Log("HIT " + alive);
    }
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        //Debug.Log("YYYYYYYYYYYY");
        if (_alive)
        {
            //Debug.Log("OH MY0");
            SetAlive(false);
            StartCoroutine(Die());
        }
    }
    private IEnumerator Die()
    {
        for (int i= 0; i < 90; i++)
        {
            this.transform.Rotate(-1, 0, 0);
            this.transform.Translate(0, -0.011f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
