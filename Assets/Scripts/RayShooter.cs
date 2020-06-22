using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _camera;
    bool cursorIsLocked;
    void Start()
    {
        cursorIsLocked = true;
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnGUI()
    {
        int size = 22;
        float posx = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posx, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (!cursorIsLocked)
            {
                Lock();
            }
            Vector3 point = new Vector3(
                _camera.pixelWidth / 2, _camera.pixelHeight / 2);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                //StartCoroutine(SphereIndicator(hit.point));
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    //Debug.Log("Shot");
                    if (target._alive)
                    {
                        Messenger.Broadcast(GameEvent.ENEMY_HIT);

                    }
                    target.ReactToHit();
                    
                    //Debug.Log("Target hit");
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cursorIsLocked = false;
        }
    }
    public void Lock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}
