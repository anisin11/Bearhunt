using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target;

    public float MouseY;

    void Update()
    {
        MouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(-MouseY, 0,0);
    }
}
