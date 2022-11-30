using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public CharaSO chara;
    public float speed = 5;
    public float multiplier = 0.3f;
    

    [SerializeField]SpriteRenderer sr;
    [SerializeField]Animator anim;

    // Start is called before the first frame update
    void Start(){
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetMouseButtonUp(0)){
            anim.SetBool("isWalking", false);
        }
        
    }
    public void Move(bool isMovingRight){
        anim.SetBool("isWalking", true);

        if(!GameManager.get.isPlaying)return;
        float dir = 1;
        if(isMovingRight){
            sr.flipX = false;
            dir = 1f;
        }else{
            sr.flipX = true;
            dir = -1f;
        }
        transform.Translate(Vector2.right * dir * speed * multiplier);
        Vector3 newPosition = transform.position;
        if(transform.position.x > 2.4f){
            newPosition.x = 2.4f;
        }else if(transform.position.x < -2.4){
            newPosition.x = -2.4f;
        }
        transform.position = newPosition;
    }
    public void SetPlayer(CharaSO value){
        chara = value;
        speed = value.speed;
        sr.sprite = value.charaImg;
        anim.runtimeAnimatorController = value.controller;

    }
}
