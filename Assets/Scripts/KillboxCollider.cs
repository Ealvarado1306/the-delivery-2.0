using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillboxCollider : MonoBehaviour
{
    public CasparStats script;
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        script = GetComponent<CasparStats>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Deathbox"){
            script.health = 0;
        }

    }
}
