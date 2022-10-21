using UnityEngine;
using System.Collections;

public class FixedCamera : MonoBehaviour {

    public Transform target;
    public float smoothTime = 0.3F;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update () {
        //Adjust 'target.position.y + 15' to make the camera zoom more in or out. Making the number bigger makes the camera zoom out
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x - 25, target.position.y + 20, target.position.z - 25), ref velocity, smoothTime);

    }
}
