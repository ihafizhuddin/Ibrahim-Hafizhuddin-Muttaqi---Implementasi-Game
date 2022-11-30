using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName  = "Ujikom/Ball")]
[SerializeField]
public class BallSO : ScriptableObject{
    public string nama;
    public int score;
    public float speed;
    public float radius;
    public Sprite image;
    
}
