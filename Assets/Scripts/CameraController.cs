using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraObject;

    Vector3 cameraPosition = Vector3.zero;
    Vector3 cameraVelocity = Vector3.zero;

    float maxZoom = 10f;
    float minZoom = 1f;
    float zoom;

    float cameraSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        zoom = maxZoom;
        cameraObject.transform.position = cameraPosition;
        cameraObject.transform.rotation = Quaternion.Euler(45f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //translation movement
        float horizontalTranslation = Input.GetAxis("Horizontal");
        float verticalTranslation = Input.GetAxis("Vertical");

        cameraVelocity = new Vector3(horizontalTranslation, 0, verticalTranslation);
        cameraVelocity *= cameraSpeed * Time.deltaTime * zoom;

        cameraPosition += cameraVelocity;

        //scroll-zoom movement
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom += scroll * 3;

        if (zoom > maxZoom )
            zoom = maxZoom;
        else if (zoom < minZoom)
            zoom = minZoom;

        cameraPosition.y = (maxZoom - minZoom) * (Mathf.Pow(zoom, 3)-minZoom)/(Mathf.Pow(maxZoom, 3) - minZoom) + minZoom;
        float zoomAngle = 30 * (zoom - minZoom)/(maxZoom - minZoom) + 50;

        //setting camera pos to internal pos var
        cameraObject.transform.position = cameraPosition;
        cameraObject.transform.rotation = Quaternion.Euler(zoomAngle, 0f, 0f);
    }
}
