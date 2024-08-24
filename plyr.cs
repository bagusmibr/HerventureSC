using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyr : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    public float jumpscale;

    Rigidbody2D body;

    SpriteRenderer sprite;

    Animator animator;
    
    public bool isground;

    public bool IsMoving = false;

    public GameObject soal, gameover;
    public GameObject finish;
    public AudioSource jump_audio, soal_audio, fall_audio;
    [SerializeField] public AudioSource footstep;
    [SerializeField] public AudioSource waterSound;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
            runright();
        }

        if(Input.GetKey(KeyCode.A)){
            runleft();
        }

        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)){
            stop();
            
        }
        if(Input.GetKeyDown(KeyCode.W) && isground){
            jump();
        }

        if(IsMoving)
        {
            if(!footstep.isPlaying)
            footstep.Play();
        }

        if(!IsMoving)
        {
            if(footstep.isPlaying)
            footstep.Stop();
        }

        if(!isground)
        {
            footstep.Stop();
        }

        if(transform.localPosition.y <-7){
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
            gameover.SetActive(true);
        }
        updateanimation();

    }

    public void runright(){
        body.velocity = new Vector2(speed,body.velocity.y);
        sprite.flipX = false;
        IsMoving = true;
    }
    public void runleft(){
        body.velocity = new Vector2(-speed,body.velocity.y);
        sprite.flipX = true;
        IsMoving = true;
    }
    public void stop(){
        body.velocity = new Vector2(0,body.velocity.y);
        IsMoving = false;
    }
    public void jump(){
        if(isground){
            body.velocity = new Vector2(body.velocity.x, jumpscale);
            jump_audio.Play();
        }
    }

    void updateanimation(){
        if(body.velocity.x>speed/2f || body.velocity.x<-speed/2f){
           animator.SetInteger("state",1);
        } else {
           animator.SetInteger("state",0); 
        }
        if(body.velocity.y>0.1f){
            animator.SetInteger("state",2);
        }
        if(body.velocity.y<-0.1f){
            animator.SetInteger("state",3);
        }
    }

    void OnTriggerEnter2D (Collider2D obj){
        if(obj.tag == "pos"){
            soal_audio.Play();
            soal.transform.GetChild(obj.transform.GetSiblingIndex()).gameObject.SetActive(true);
        }

         if(obj.tag == "groundLimit"){
            fall_audio.Play();
            waterSound.Play();
            gameObject.SetActive(true);
        }

        if(obj.tag == "finish"){
            finish.SetActive(true);
        }

    }  
 
}
