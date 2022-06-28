using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTouchScript : MonoBehaviour
{
    Ray ray;
    public Rigidbody kobaja;
 
    bool mousePressed;
    public int power;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 force;

    public LineRenderer lineRend;

    private void Start()
    {
        lineRend.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {          // on mouse click

            ray = Camera.main.ScreenPointToRay (Input.mousePosition);

            mousePressed = true;

            startPoint = new Vector3(kobaja.transform.position.x, kobaja.transform.position.y, 0);

            lineRend.enabled = true;
        }

        if (lineRend.enabled)
        {
            lineRend.SetPosition(0, kobaja.transform.position);
        }

        if (mousePressed)   // while the mouse is pressed down
        {     
            endPoint = endPoint = Camera.main.ScreenToWorldPoint(
                                new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * (-1)));
            print(endPoint);

            lineRend.SetPosition(1, endPoint);
        }

        force = (startPoint - endPoint) * power;

        if (Input.GetMouseButtonUp(0)) {            // on mouse release

            mousePressed = false;

            kobaja.AddForce(force);

            GameManager.Instance.hitSoundPlayed = false;

            lineRend.enabled = false;
        }

     
    }

}
