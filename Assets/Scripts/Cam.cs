using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;   // an object camera will follow
    [SerializeField] private Vector3 distanceFromObject; // camera's distance from obj

    public float smoothness;

    private void LateUpdate()   // works after all update functions called
    {
        // target position of the camera
        Vector3 goToPosition = objectToFollow.transform.position + distanceFromObject;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, goToPosition, smoothness);

        if (Time.timeScale != 0.5)
        {
            transform.position = smoothPosition;
        }
        else
        {
            transform.LookAt(objectToFollow.transform);
            transform.Translate(new Vector3(0, 0, 3 * Time.deltaTime), Space.World);
        }
    }
}
