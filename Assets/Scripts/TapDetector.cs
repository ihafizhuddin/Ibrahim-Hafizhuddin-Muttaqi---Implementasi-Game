using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDetector : MonoBehaviour{
    public bool isMovingRight = true;
    public bool isMouseOver = false;
    // Start is called before the first frame update
    // void Start(){
        
    // }

    // // Update is called once per frame
    void Update(){
        if(Input.GetMouseButton(0) && isMouseOver){
            GameManager.get.player.Move(isMovingRight);
            
        }
    }
    public void OnMouseOver(){
        isMouseOver = true;
    }
    public void OnMouseExit(){
        isMouseOver = false;
    }
    // public void OnMouseDown(){
    //     GameManager.get.player.Move(isMovingRight);
    // }
}
