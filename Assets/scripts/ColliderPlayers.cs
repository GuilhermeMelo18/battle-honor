using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColliderPlayers : MonoBehaviour {

    
    public GameObject Guerreira;
    public GameObject Heroi;
    public GameObject Skeleton;
    public GameObject Sword;
    public GameObject Shield;
    public GameObject Power;
    public AudioClip AudioGuerreira;
    public AudioClip AudioHeroi;
    public AudioClip AudioSkeleton;
    public AudioClip AudioLoseGuerreira;
    public AudioClip AudioLoseHeroi;
    public AudioClip AudioLoseSkeleton;

    public ParticleSystem ParticleGuerreira;
    public ParticleSystem ParticleHeroi;
    public ParticleSystem ParticleSkeleton;

    public Slider HpPlayerOne;
    public Slider HpPlayerTwo;
    public Slider PowerPlayerOne;
    public Slider PowerPlayerTwo;

    public Image ShieldPlayerOne;
    public Image ShieldPlayerTwo;
    public Image SwordPlayerOne;
    public Image SwordPlayerTwo;
    public Image SpecialPlayerOne;
    public Image SpecialPlayerTwo;


       
    private int DamagePlayerOne = 0;
    private int DamagePlayerTwo = 0;
    private int DefensePlayerOne = 0;
    private int DefensePlayerTwo = 0;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        ChangeAttackDefense();
    }

    void OnTriggerEnter(Collider other)
    {

        if ((other.name.Equals("Zombie_0_4") && ParticleHeroi.tag.Equals("Direito")))
        {
            VerificarPlayTwo();
            VerificarMorte(Heroi,HpPlayerTwo.value);
        }
        else if (other.name.Equals("Zombie_0_4") && ParticleHeroi.tag.Equals("Esquerdo"))
        {
            VerificarPlayOne();
            VerificarMorte(Heroi, HpPlayerOne.value);
        }
        else if ((other.name.Equals("skeleton_swordsman") && ParticleSkeleton.tag.Equals("Direito")))
        {
            VerificarPlayTwo();
            VerificarMorte(Skeleton, HpPlayerTwo.value);
        }
        else if ((other.name.Equals("skeleton_swordsman") && ParticleSkeleton.tag.Equals("Esquerdo")))
        {
            VerificarPlayOne();
            VerificarMorte(Skeleton, HpPlayerOne.value);
        }
    }

    private void VerificarPlayTwo() {
        
        HpPlayerTwo.value -= 3 + (DamagePlayerOne - DefensePlayerTwo);
        PowerPlayerOne.value += 3;

        if (PowerPlayerOne.value >= 49)
        {
            Guerreira.GetComponent<Animator>().Play("POWER");
            Guerreira.GetComponent<AudioSource>().PlayOneShot(AudioGuerreira);
            HpPlayerTwo.value -= 7;
            ParticleGuerreira.Play();
            PowerPlayerOne.value = 0;
        }
        else if (PowerPlayerOne.value >= 9 && PowerPlayerOne.value <= 40)
        {
            ParticleGuerreira.Stop();
        }

    }

    private void VerificarPlayOne() {

        HpPlayerOne.value -= 3 + (DamagePlayerTwo - DefensePlayerOne);
        PowerPlayerTwo.value += 3;

        if (PowerPlayerTwo.value >= 49)
        {
            Guerreira.GetComponent<Animator>().Play("POWER");
            Guerreira.GetComponent<AudioSource>().PlayOneShot(AudioGuerreira);
            HpPlayerOne.value -= 7;
            ParticleGuerreira.Play();
            PowerPlayerTwo.value = 0;
        }
        else if (PowerPlayerTwo.value >= 9 && PowerPlayerTwo.value <= 40)
        {
            ParticleGuerreira.Stop();
        }

    }

    private void VerificarMorte(GameObject gameObject, float hp) {

        if (hp<=0) {

            gameObject.GetComponent<Animator>().Play("LOSE");

        if (gameObject.name.Equals("Zombie_0_4")) {

                gameObject.GetComponent<AudioSource>().PlayOneShot(AudioLoseHeroi);
            } else if (gameObject.name.Equals("skeleton_swordsman")) {


                gameObject.GetComponent<AudioSource>().PlayOneShot(AudioLoseSkeleton);

            }
        
        }
    }

    private void ChangeAttackDefense() {

        if (Vector3.Distance(Sword.transform.position, Guerreira.transform.position) < 9)
        {

            ImageSwitch(Sword.tag, ParticleGuerreira.tag);

        }
        else if (Vector3.Distance(Shield.transform.position, Guerreira.transform.position) < 9)
        {

            ImageSwitch(Shield.tag, ParticleGuerreira.tag);

        }
        else if (Vector3.Distance(Power.transform.position, Guerreira.transform.position) < 9)
        {

            ImageSwitch(Power.tag, ParticleGuerreira.tag);

        }
        else if (Vector3.Distance(Sword.transform.position, Heroi.transform.position) < 9)
        {

            ImageSwitch(Sword.tag, ParticleHeroi.tag);

        }
        else if (Vector3.Distance(Shield.transform.position, Heroi.transform.position) < 9)
        {

            ImageSwitch(Shield.tag, ParticleHeroi.tag);
        }
        else if (Vector3.Distance(Power.transform.position, Heroi.transform.position) < 9)
        {

            ImageSwitch(Power.tag, ParticleHeroi.tag);
        }
        else if (Vector3.Distance(Sword.transform.position, Skeleton.transform.position) < 9)
        {
            ImageSwitch(Sword.tag, ParticleSkeleton.tag);
        }
        else if (Vector3.Distance(Shield.transform.position, Skeleton.transform.position) < 9)
        {
            ImageSwitch(Shield.tag, ParticleSkeleton.tag);
        }
        else if (Vector3.Distance(Power.transform.position, Skeleton.transform.position) < 9)
        {
            ImageSwitch(Power.tag, ParticleSkeleton.tag);
        }
    }

    private void ImageSwitch(string material,string lado)
    {

        if (lado.Equals("Esquerdo"))
        {

            if (material.Equals("Sword"))
            {

                if (SwordPlayerOne.IsActive())
                {
                    SwordPlayerOne.enabled = false;
                    this.DamagePlayerOne = 4;
                }
                else
                {
                    SwordPlayerOne.enabled = true;
                    this.DamagePlayerOne = 0;
                }

            }
            else if (material.Equals("Shield"))
            {

                if (ShieldPlayerOne.IsActive())
                {
                    ShieldPlayerOne.enabled = false;
                    this.DefensePlayerOne = 2;
                }
                else
                {
                    ShieldPlayerOne.enabled = true;
                    this.DefensePlayerOne = 0;
                }
            }
            else if (material.Equals("Power"))
            {

                if (SpecialPlayerOne.IsActive())
                {
                    SpecialPlayerOne.enabled = false;
                    this.PowerPlayerOne.value += 25;
                }
                else
                {
                    SpecialPlayerOne.enabled = true;
                }

            }

        }
        else if (lado.Equals("Direito")) {

            if (material.Equals("Sword"))
            {

                if (SwordPlayerTwo.IsActive())
                {
                    SwordPlayerTwo.enabled = false;
                    this.DamagePlayerTwo = 4;
                }
                else
                {
                    SwordPlayerTwo.enabled = true;
                    this.DamagePlayerTwo = 0;
                }

            }
            else if (material.Equals("Shield"))
            {

                if (ShieldPlayerTwo.IsActive())
                {
                    ShieldPlayerTwo.enabled = false;
                    this.DefensePlayerTwo = 2;
                }
                else
                {
                    ShieldPlayerTwo.enabled = true;
                    this.DefensePlayerTwo = 0;
                }
            }
            else if (material.Equals("Power"))
            {

                if (SpecialPlayerTwo.IsActive())
                {
                    SpecialPlayerTwo.enabled = false;
                    this.PowerPlayerTwo.value += 25;
                }
                else
                {
                    SpecialPlayerOne.enabled = true;
                }

            }
            
        }


    }

}
