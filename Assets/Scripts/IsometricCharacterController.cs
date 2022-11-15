using UnityEngine;
using System.Collections;

public class IsometricCharacterController : MonoBehaviour {

    Vector3 forward, right;
    public float moveSpeed;
    Animator anim;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        // -45 degrees from the world x axis
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;

        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        // Movement
        if (Input.anyKey) {
            if(!audioSource.isPlaying){
                audioSource.Play();
            }
            Move();
        }

        // No Movement
        else{
            anim.SetFloat("Speed", 0);
            audioSource.Stop();
        }

	}

    void Move() {

        // Movement speed
        Vector3 rightMovement = right * moveSpeed * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Input.GetAxis("Vertical");

        // Calculate what is forward
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        // Set new position
        Vector3 newPosition = transform.position;
        newPosition += rightMovement;
        newPosition += upMovement;

        // Smoothly move the new position
        transform.forward = heading;
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);

        //Setting velocity for walk/run animations
        var velocity_ver = Vector3.forward * Input.GetAxis("Vertical") * moveSpeed;
        var velocity_hor = Vector3.forward * Input.GetAxis("Horizontal") * moveSpeed;
        var velocity = (Mathf.Abs(velocity_ver.z) + Mathf.Abs(velocity_hor.z))/2;
        anim.SetFloat("Speed", velocity);

    }

   
}
