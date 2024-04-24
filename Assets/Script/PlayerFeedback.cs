using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedback : MonoBehaviour
{
    bool isKnockback = false;
    float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col){  
        if(col.tag == "Enemy"){
           isKnockback = true;    
           Vector3 direction = (transform.position - col.transform.position).normalized;

           col.GetComponent<Rigidbody>().AddForce (direction * speed);
        }
    }
    private void OnTriggerExit(Collider col){
        if(col.tag == "Enemy"){
           isKnockback = false;    
        }
    }

    

    
}
