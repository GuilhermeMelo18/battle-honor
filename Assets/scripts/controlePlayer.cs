using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class controlePlayer : MonoBehaviour {

    public GameObject Guerreira;
    public GameObject Skeleton;
    public GameObject Heroi;
    public AudioClip AudioAttackGuerreira;
    public AudioClip AudioJumpGuerreira;
    public AudioClip AudioAttackHeroi;
    public AudioClip AudioJumpHeroi;
    public AudioClip AudioAttackSkeleton;
    public AudioClip AudioJumpSkeleton;
    public AudioClip AudioGo;



    // Use this for initialization
    void Start() {
        

        GetComponent<AudioSource>().PlayOneShot(AudioGo, 0.3f);
    }

    // Update is called once per frame
    void Update() {



    }

    public void JumpPlayer() {
        if (Guerreira.tag == "PlayerOne")
        {
            Guerreira.GetComponent<Animator>().Play("JUMP");
            GetComponent<AudioSource>().PlayOneShot(AudioJumpGuerreira, 0.3f);
        }
        else if (Heroi.tag == "PlayerOne")
        {
            Heroi.GetComponent<Animator>().Play("JUMP");

            GetComponent<AudioSource>().PlayOneShot(AudioJumpHeroi, 0.3f);
        }
        else if (Skeleton.tag == "PlayerOne")
        {
            Skeleton.GetComponent<Animator>().Play("JUMP");

            GetComponent<AudioSource>().PlayOneShot(AudioJumpSkeleton, 0.3f);
        }
        
    }

    public void AttackPlayer() {
        if (Guerreira.tag == "PlayerOne")
        {
            Guerreira.GetComponent<Animator>().Play("ATTACK");

            GetComponent<AudioSource>().PlayOneShot(AudioAttackGuerreira, 0.3f);
        }
        else if (Heroi.tag == "PlayerOne")
        {
            Heroi.GetComponent<Animator>().Play("ATTACK");
            GetComponent<AudioSource>().PlayOneShot(AudioAttackHeroi, 0.3f);
        }
        else if (Skeleton.tag == "PlayerOne")
        {
            Skeleton.GetComponent<Animator>().Play("ATTACK");
            GetComponent<AudioSource>().PlayOneShot(AudioAttackSkeleton, 0.3f);
        }
    }

    public void resetScene() {
        
        SceneManager.LoadScene("gameScene");

    }
    
}

