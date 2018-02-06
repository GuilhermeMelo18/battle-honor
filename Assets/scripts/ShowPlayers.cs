using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayers : MonoBehaviour {

    public GameObject Guerreira;
    public GameObject Skeleton;
    public GameObject Heroi;
    public ParticleSystem pGuerreira;
    public ParticleSystem pHeroi;
    public ParticleSystem pSkeleton;
    public Text P1Text;
    public Text P2Text;
    public Text P3Text;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        
        if ((Guerreira.tag.Equals("PlayerOne") && (Heroi.tag.Equals("PlayerTwo") || (Skeleton.tag.Equals("PlayerTwo"))))
            || (Heroi.tag.Equals("PlayerOne") && (Guerreira.tag.Equals("PlayerTwo") || (Skeleton.tag.Equals("PlayerTwo"))))
            || (Skeleton.tag.Equals("PlayerOne") && (Heroi.tag.Equals("PlayerTwo") || (Guerreira.tag.Equals("PlayerTwo"))))
            )
        {
            if (Guerreira.tag.Equals("PlayerOne") && (Heroi.tag.Equals("PlayerTwo") && (Skeleton.tag.Equals("PlayerTwo"))))
            {
                P1Text.text = "Guerreira";
                pGuerreira.tag = "Esquerdo";

                P2Text.text = "Heroi";
                pHeroi.tag = "Direito";

                P3Text.text = "Skeleton";
                pSkeleton.tag = "Direito";


            } else if ((Heroi.tag.Equals("PlayerOne") && (Guerreira.tag.Equals("PlayerTwo") && (Skeleton.tag.Equals("PlayerTwo"))))) {

                P1Text.text = "Heroi";
                pHeroi.tag = "Esquerdo";

                P2Text.text = "Guerreira";
                pGuerreira.tag = "Direito";

                P3Text.text = "Skeleton";
                pSkeleton.tag = "Direito";

            } else if ((Skeleton.tag.Equals("PlayerOne") && (Heroi.tag.Equals("PlayerTwo") && (Guerreira.tag.Equals("PlayerTwo"))))) {

                P1Text.text = "Skeleton";
                pSkeleton.tag = "Esquerdo";

                P2Text.text = "Heroi";
                pHeroi.tag = "Direito";

                P3Text.text = "Guerreira";
                pGuerreira.tag = "Direito";
            }
            else {

                if (Guerreira.tag.Equals("PlayerOne"))
                {

                    if (Heroi.tag.Equals("PlayerTwo"))
                    {
                        P1Text.text = "Guerreira";
                        pGuerreira.tag = "Esquerdo";

                        P2Text.text = "Heroi";
                        pHeroi.tag = "Direito";

                        P3Text.text = "";
                    }
                    else if (Skeleton.tag.Equals("PlayerTwo"))
                    {
                        P1Text.text = "Guerreira";
                        pGuerreira.tag = "Esquerdo";

                        P2Text.text = "Skeleton";
                        pSkeleton.tag = "Direito";

                        P3Text.text = "";
                    }
                }
                else if (Heroi.tag.Equals("PlayerOne"))
                {
                    if (Guerreira.tag.Equals("PlayerTwo"))
                    {

                        P1Text.text = "Heroi";
                        pHeroi.tag = "Esquerdo";

                        P2Text.text = "Guerreira";
                        pGuerreira.tag = "Direito";

                        P3Text.text = "";
                    }
                    else if (Skeleton.tag.Equals("PlayerTwo"))
                    {

                        P1Text.text = "Heroi";
                        pHeroi.tag = "Esquerdo";

                        P2Text.text = "Skeleton";
                        pSkeleton.tag = "Direito";

                        P3Text.text = "";
                    }
                }
                else if (Skeleton.tag.Equals("PlayerOne"))
                {

                    if (Heroi.tag.Equals("PlayerTwo"))
                    {
                        P1Text.text = "Skeleton";
                        pSkeleton.tag = "Esquerdo";

                        P2Text.text = "Heroi";
                        pHeroi.tag = "Direito";

                        P3Text.text = "";
                    }
                    else if (Guerreira.tag.Equals("PlayerTwo"))
                    {
                        P1Text.text = "Skeleton";
                        pSkeleton.tag = "Esquerdo";

                        P2Text.text = "Guerreira";
                        pGuerreira.tag = "Direito";

                        P3Text.text = "";
                    }
                }
            }
        }
        else {
            
            if (Guerreira.tag.Equals("PlayerTwo"))
            {
                if (Heroi.tag.Equals("PlayerTwo"))
                {
                    P1Text.text = "Guerreira";
                    pGuerreira.tag = "Esquerdo";

                    P2Text.text = "Heroi";
                    pHeroi.tag = "Direito";

                    P3Text.text = "";
                }
                else if (Skeleton.tag.Equals("PlayerTwo"))
                {

                    P1Text.text = "Guerreira";
                    pGuerreira.tag = "Esquerdo";

                    P2Text.text = "Skeleton";
                    pSkeleton.tag = "Direito";

                    P3Text.text = "";
                }
            }
            else if (Heroi.tag.Equals("PlayerTwo"))
            {

                if (Guerreira.tag.Equals("PlayerTwo"))
                {
                    P1Text.text = "Heroi";
                    pHeroi.tag = "Esquerdo";

                    P2Text.text = "Guerreira";
                    pGuerreira.tag = "Direito";

                    P3Text.text = "";
                }
                else if (Skeleton.tag.Equals("PlayerTwo"))
                {
                    P1Text.text = "Heroi";
                    pHeroi.tag = "Esquerdo";

                    P2Text.text = "Skeleton";
                    pSkeleton.tag = "Direito";

                    P3Text.text = "";
                }

            }
            else if (Skeleton.tag.Equals("PlayerTwo"))
            {
                if (Heroi.tag.Equals("PlayerTwo"))
                {
                    P1Text.text = "Skeleton";
                    pSkeleton.tag = "Esquerdo";

                    P2Text.text = "Heroi";
                    pHeroi.tag = "Direito";

                    P3Text.text = "";
                }
                else if (Guerreira.tag.Equals("PlayerTwo"))
                {
                    P1Text.text = "Skeleton";
                    pSkeleton.tag = "Esquerdo";

                    P2Text.text = "Guerreira";
                    pGuerreira.tag = "Direito";

                    P3Text.text = "";
                }
            }


        }
        
    }
}
