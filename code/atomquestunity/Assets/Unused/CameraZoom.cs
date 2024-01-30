using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier = 50f;
    private float minZoom = 4f;
    private float maxZoom = 100f;
    private float velocity = 0;
    private float smoothTime = 0.25f;

    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        zoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        // Get scroll wheel input
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        // Check if there's any input from the scroll wheel
        if (scrollWheelInput != 0)
        {
            // Adjust the zoom based on the scroll wheel input
            zoom -= scrollWheelInput * zoomMultiplier;
            zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        }
    }
}
