using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{
    public BallSO ball;
    public string ballName;
    public float ballSpeed;
    public float speedMultiplier = 0.3f;
    public int ballScore;
    public float ballRadius;
    public float scaleMultiplier = 2f;
    private SpriteRenderer sr;

    public void SetBall(BallSO value){
        ball = value;
        if(sr == null) sr = GetComponent<SpriteRenderer>();
        ballName = ball.nama;
        ballSpeed = ball.speed;
        ballScore = ball.score;
        ballRadius = ball.radius;
        sr.sprite = ball.image;
        Vector3 newScale = new Vector3(ballRadius,ballRadius,ballRadius) * scaleMultiplier;
        transform.localScale = newScale;
        

    }

    public void OnEnable() {
        if(sr == null) sr = GetComponent<SpriteRenderer>();
        // ballName = ball.nama;
        // ballSpeed = ball.speed;
        // ballScore = ball.score;
        // sr.sprite = ball.image;
    }

    // Start is called before the first frame update
    void Start(){
        if(sr == null) sr = GetComponent<SpriteRenderer>();
        // ballName = ball.nama;
        // ballSpeed = ball.speed;
        // ballScore = ball.score;
    }

    // Update is called once per frame
    void Update(){
        Move();
    }

    public void Move(){
        transform.Translate(Vector2.down * ballSpeed * Time.deltaTime * speedMultiplier);
    }
    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            GameManager.get.AddScore(ballScore);
            gameObject.SetActive(false);
        }else if(col.gameObject.tag == "Ground"){
            GameManager.get.MinHealth();
            gameObject.SetActive(false);
        }
        
    }
}
