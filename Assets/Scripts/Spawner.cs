using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
    public static Spawner ins;
    public List<BallSO> ballToSpawn;
    public Ball ballPrefab;
    public float cdTimer;
    [SerializeField] Transform rightEdge;
    [SerializeField] Transform leftEdge;
    [SerializeField] List<Ball> ballPool;

    void Awake(){
        ins = this;
    }
    // // Start is called before the first frame update
    // void Start(){
        
    // }

    // Update is called once per frame
    void Update(){
        KurangiCd();
    }

    public void KurangiCd(){
        cdTimer -= Time.deltaTime;
        if(cdTimer <= 0){
            SpawnBola();
            cdTimer = GameManager.get.SetCoolDown(GameManager.get.score);
        }
    }
    public void SpawnBola(){
        Ball newBall = ballPool.Find(x => x.gameObject.activeInHierarchy == false);
        int ballRng = Random.Range(0, ballToSpawn.Count);
        float xPos = Random.Range(rightEdge.position.x, leftEdge.position.x);
        Vector3 spawnPos = transform.position;
        spawnPos.x = xPos;
        if(newBall == null){
            newBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);
            ballPool.Add(newBall);
        }
        newBall.SetBall(ballToSpawn[ballRng]);
        newBall.transform.position = spawnPos;
        newBall.transform.rotation = Quaternion.identity;
        newBall.gameObject.SetActive(true);
    }

    public void CleanPool(){
        foreach (Ball item in ballPool){
            item.gameObject.SetActive(false);
        }
    }
}
