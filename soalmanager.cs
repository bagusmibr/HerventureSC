using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class soalmanager : MonoBehaviour
{
    public AudioSource benar_audio, salah_audio;
    public TMP_Text skor_T, terjawab_T;
    public Color warnatombolbenar, warnatombolsalah;
    int skor= 0, soalterjawab=0;
    public plyr movementScript;

    public string [] kuncijawaban;

    int nomor(){
        int a = 0;
            for(int i=0;i<transform.childCount;i++){
                if(transform.GetChild(i).gameObject.activeSelf){
                    a = i;
                }
        }
        return a;
    }

    public void jawab(GameObject tombol){
        
        for(int i=0;i<tombol.transform.parent.childCount;i++){
            tombol.transform.parent.GetChild(i).GetComponent<Button>().enabled = false;
        }
         
        if(tombol.name == kuncijawaban[nomor()]){
            benar_audio.Play();
            tombol.GetComponent<Image>().color = warnatombolbenar;
            skor+=10;
        }else {
            salah_audio.Play();
            tombol.GetComponent<Image>().color = warnatombolsalah;
        }
        soalterjawab++;
        StartCoroutine(tutupsoal());
    }

    IEnumerator tutupsoal(){
        yield return new WaitForSeconds(1.5f);
        transform.GetChild(nomor()).gameObject.SetActive(false);
        movementScript.speed = 7f;
    }

    void Update(){
        skor_T.text = "Skor : "+skor;
        terjawab_T.text = "Soal : "+soalterjawab+" / 10";
    }

}
