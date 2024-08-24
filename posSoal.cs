using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class posSoal : MonoBehaviour
{
    public BoxCollider2D colSoal;
    public plyr movementScript;
    
    void OnTriggerEnter2D (Collider2D obj){
        if(obj.tag == "Player"){
            colSoal.enabled = false;
            movementScript.speed = 0f;
        }

    }
}
