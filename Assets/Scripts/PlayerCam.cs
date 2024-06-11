using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] Transform objectTofollow;
    [SerializeField] Transform playerObj;
    [SerializeField] float followSpeed = 10f;
    [SerializeField] float sensitivity = 100f;
    [SerializeField] float clampAngle = 50f;

    float rotX;
    float rotY;

    [SerializeField] Transform realCamera;
    [SerializeField] Vector3 dirNormalized;
    [SerializeField] Vector3 finalDir;
    [SerializeField] float minDistance;
    [SerializeField] float maxDistance;
    [SerializeField] float finalDistance;
    [SerializeField] float smoothness = 10f;


    void Start()
    {
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = realCamera.localPosition.normalized;
        finalDistance = realCamera.localPosition.magnitude;
    }

    void Update()
    {
        cameraRotation();
    }

    private void LateUpdate()
    {
        //cameraFollow();
    }

    private void cameraRotation()
    {
        rotX += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -1;
        rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle + 30f, clampAngle);
        Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
        Quaternion rotPlayer = Quaternion.Euler(0, rotY, 0);
        transform.rotation = rot;
        playerObj.rotation = rotPlayer;
    }

    private void cameraFollow()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectTofollow.position, followSpeed * Time.deltaTime);

        finalDir = transform.TransformPoint(dirNormalized * maxDistance);

        RaycastHit hit;

        if (Physics.Linecast(transform.position, finalDir, out hit))
        {
            finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            finalDistance = maxDistance;
        }

        realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, dirNormalized * finalDistance, smoothness * Time.deltaTime);
    }
}
