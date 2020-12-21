using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class MouseOrbit : MonoBehaviour
{

    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    public float smooth;

    [HideInInspector]
    public Quaternion newRotation;
    public float newDistance;

    private Rigidbody rb;

    float x = 0.0f;
    float y = 0.0f;

    Vector3 center;
    Vector3 vel;
    Vector3 rotVel;
    float distVel;



    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rb = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }


    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            newRotation = Quaternion.Euler(y, x, 0);
        }

        Quaternion rotation = Quaternion.Lerp(transform.rotation, newRotation, smooth);

        if (!Mathf.Approximately(Input.GetAxisRaw("Mouse ScrollWheel"), 0f))
        {
            newDistance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
        }
        distance = Mathf.SmoothDamp(distance, newDistance, ref distVel, smooth);

        RaycastHit hit;
        if (Physics.Linecast(target.position, transform.position, out hit))
        {
            distance -= hit.distance;
        }

        center = Vector3.SmoothDamp(center, target.position, ref vel, smooth);

        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + center;

        transform.position = position;
        transform.rotation = rotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}