using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseCharaButton : MonoBehaviour{
    public CharaSO charaToChoose;
    public TMP_Text nameCharaTMP;
    public Image charaImg;
    // Start is called before the first frame update
    void Start(){
        charaImg.sprite = charaToChoose.charaImg;
        nameCharaTMP.text = charaToChoose.nama;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    public void ChooseChara(){
        GameManager.get.ChooseChara(charaToChoose);
        transform.parent.gameObject.SetActive(false);
    }
}
