using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ataquePlayer : MonoBehaviour {

    public GameObject Heroi;
    public GameObject Guerreira;
    public GameObject Skeleton;
    public AudioClip AudioAttackGuerreira;
    public AudioClip AudioJumpGuerreira;
    public AudioClip AudioWaitGuerreira;
    public AudioClip AudioAttackHeroi;
    public AudioClip AudioJumpHeroi;
    public AudioClip AudioWaitHeroi;
    public AudioClip AudioAttackSkeleton;
    public AudioClip AudioJumpSkeleton;
    public AudioClip AudioWaitSkeleton;
    

    // Use this for initialization
    void Start () {
            
    }

    
    // Update is called once per frame
    void Update () {


        if (this.tag.Equals("PlayerTwo")&&(Guerreira.tag.Equals("PlayerOne")||
            Heroi.tag.Equals("PlayerOne") || Skeleton.tag.Equals("PlayerOne")))
        {

            if (Guerreira.tag.Equals("PlayerOne"))
            {
                direcionarPlayer(Guerreira.transform);

                fightTwoPlay(Guerreira);

                switchAnimation(Guerreira);
            }
            else if (Heroi.tag.Equals("PlayerOne"))
            {

                direcionarPlayer(Heroi.transform);

                fightTwoPlay(Heroi);

                switchAnimation(Heroi);
            }
            else if (Skeleton.tag.Equals("PlayerOne"))
            {

                direcionarPlayer(Skeleton.transform);
                fightTwoPlay(Skeleton);
                switchAnimation(Skeleton);
            }
        }
        else if (this.tag.Equals("PlayerTwo"))
        {
            if (this.name.Equals("unitychan"))
            {
                if (Heroi.tag.Equals("PlayerTwo"))
                {

                    direcionarPlayer(Heroi.transform);
                    fightTwoPlay(Heroi);
                    switchAnimation(Heroi);
                }
                else if (Skeleton.tag.Equals("PlayerTwo"))
                {
                    direcionarPlayer(Skeleton.transform);
                    fightTwoPlay(Skeleton);
                    switchAnimation(Skeleton);
                }
            }
            else if (this.name.Equals("Zombie_0_4"))
            {
                if (Guerreira.tag.Equals("PlayerTwo"))
                {

                    direcionarPlayer(Guerreira.transform);
                    fightTwoPlay(Guerreira);
                    switchAnimation(Guerreira);
                }
                else if (Skeleton.tag.Equals("PlayerTwo"))
                {
                    direcionarPlayer(Skeleton.transform);
                    fightTwoPlay(Skeleton);
                    switchAnimation(Skeleton);
                }
            }
            else
            {
                if (Heroi.tag.Equals("PlayerTwo"))
                {

                    direcionarPlayer(Heroi.transform);
                    fightTwoPlay(Heroi);
                    switchAnimation(Heroi);
                }
                else if (Guerreira.tag.Equals("PlayerTwo"))
                {
                    direcionarPlayer(Guerreira.transform);
                    fightTwoPlay(Guerreira);
                    switchAnimation(Guerreira);
                }
            }
            
        }
        else if(this.tag.Equals("PlayerOne"))
        {

            if (Guerreira.tag.Equals("PlayerTwo"))
            {
                direcionarPlayer(Guerreira.transform);
                switchAnimation(Guerreira);
            }
            else if (Heroi.tag.Equals("PlayerTwo"))
            {

                direcionarPlayer(Heroi.transform);
                switchAnimation(Heroi);
            }
            else if (Skeleton.tag.Equals("PlayerTwo"))
            {
                direcionarPlayer(Skeleton.transform);
                switchAnimation(Skeleton);
            }
        }

    }


    private void direcionarPlayer(Transform t2Player) {

        transform.LookAt(t2Player);

    }

    private void switchAnimation(GameObject alvo) {

        if (Vector3.Distance(alvo.transform.position, this.transform.position) <= 11 &&
            Vector3.Distance(alvo.transform.position, this.transform.position) >= 9 && !GetComponent<AudioSource>().isPlaying)
        {

            GetComponent<Animator>().Play("WAIT02");

            if (this.name.Equals("unitychan"))
            {
                GetComponent<AudioSource>().PlayOneShot(AudioWaitGuerreira, 0.3f);
            }
            else if (this.name.Equals("Zombie_0_4"))
            {
                GetComponent<AudioSource>().PlayOneShot(AudioWaitHeroi, 0.3f);
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(AudioWaitSkeleton, 0.3f);
            }

        }

    }

    private void fightTwoPlay(GameObject alvo) {
        
        if (Vector3.Distance(alvo.transform.position, this.transform.position) < 9
            && Vector3.Distance(alvo.transform.position, this.transform.position) > 7)
        {
            int j = UnityEngine.Random.Range(0, 55);

            if (j == 0 && !GetComponent<AudioSource>().isPlaying)
            {

                GetComponent<Animator>().Play("JUMP");

                if (this.name.Equals("unitychan"))
                {
                    GetComponent<AudioSource>().PlayOneShot(AudioJumpGuerreira, 0.3f);
                }
                else if (this.name.Equals("Zombie_0_4"))
                {
                    GetComponent<AudioSource>().PlayOneShot(AudioJumpHeroi, 0.3f);
                }
                else
                {
                    GetComponent<AudioSource>().PlayOneShot(AudioJumpSkeleton, 0.3f);
                }

            }
        }
        else
            if (Vector3.Distance(alvo.transform.position, this.transform.position) <= 7){

                int i = UnityEngine.Random.Range(0, 58);

                if (i == 0 && !GetComponent<AudioSource>().isPlaying) {
                
                    GetComponent<Animator>().Play("ATTACK");

                if (this.name.Equals("unitychan"))
                {
                    GetComponent<AudioSource>().PlayOneShot(AudioAttackGuerreira, 0.3f);
                }
                else if (this.name.Equals("Zombie_0_4"))
                {
                    GetComponent<AudioSource>().PlayOneShot(AudioAttackHeroi, 0.3f);
                }
                else {
                    GetComponent<AudioSource>().PlayOneShot(AudioAttackSkeleton, 0.3f);
                }
                    
                    
                }
            

        }
    }
    
    
}
