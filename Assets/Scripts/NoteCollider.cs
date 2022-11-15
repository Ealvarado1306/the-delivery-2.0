using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollider : MonoBehaviour
{
    public CasparStats script;
    public Rigidbody rb;
    public AudioSource damageSound;

    void Start(){
        script = GetComponent<CasparStats>();
        rb = GetComponent<Rigidbody>();
        Debug.Log(script.health);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.J)) {
            script.playerHit();
        }
    }

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Note"){
            damageSound.Play();
            Destroy(col.gameObject);
            script.playerHit();
        }

    }

}
