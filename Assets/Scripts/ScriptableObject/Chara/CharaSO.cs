using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ujikom/Chara")]
public class CharaSO : ScriptableObject{
    public string nama;
    public float speed;
    public int nyawa;
    public Sprite charaImg;
    public RuntimeAnimatorController controller;
}
