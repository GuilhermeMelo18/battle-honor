/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

    #endregion // PRIVATE_MEMBER_VARIABLES

    public GameObject Guerreira;
    public GameObject Heroi;
    public GameObject Skeleton;
    public AudioClip SelectPlayerOne;
    public AudioClip SelectPlayerTwo;
    public GameObject Attack;
    public GameObject Shield;
    public GameObject Power;

    public AudioClip AudioEstagio1;
    public GameObject GameSounds;
    public AudioClip AudioEstagio2;

    private int MakeSoundEstagio1 = 0;
    private int MakeSoundEstagio2 = 0;

    #region UNTIY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            if (mTrackableBehaviour.TrackableName.Equals("markerDefesa") ||
                mTrackableBehaviour.TrackableName.Equals("Swords") ||
                mTrackableBehaviour.TrackableName.Equals("markerPower") ||
                mTrackableBehaviour.TrackableName.Equals("markerEstagio1") || 
                mTrackableBehaviour.TrackableName.Equals("markerEstagio2"))
            {
                ChangeObjects(mTrackableBehaviour.TrackableName);
            }
            else {
                ChangePlayer(mTrackableBehaviour.TrackableName);
            }
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            if (mTrackableBehaviour.TrackableName.Equals("markerDefesa") ||
                mTrackableBehaviour.TrackableName.Equals("Swords") ||
                mTrackableBehaviour.TrackableName.Equals("markerPower")||
                mTrackableBehaviour.TrackableName.Equals("markerEstagio1")||
                mTrackableBehaviour.TrackableName.Equals("markerEstagio2"))
            {
                DesactiveObjects(mTrackableBehaviour.TrackableName);
            }
            else
            {
                LostTracking(mTrackableBehaviour.TrackableName);
            }

            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    public void ChangeObjects(string objeto) {

        if (objeto.Equals("markerDefesa"))
        {
            Shield.tag = "Shield";
        }
        else if (objeto.Equals("Swords"))
        {

            Attack.tag = "Sword";
        }
        else if (objeto.Equals("markerPower"))
        {

            Power.tag = "Power";
        }
        else if (objeto.Equals("markerEstagio1")) {

            if (MakeSoundEstagio1 == 0) {

                if (GameSounds.GetComponent<AudioSource>().isPlaying)
                {
                    GameSounds.GetComponent<AudioSource>().Stop();
                }
                GameSounds.GetComponent<AudioSource>().PlayOneShot(AudioEstagio1, 0.15f);
            }
            MakeSoundEstagio1 = 1;
            MakeSoundEstagio2 = 0;

        } else if (objeto.Equals("markerEstagio2")) {

            if (MakeSoundEstagio2 == 0)
            {
                if (GameSounds.GetComponent<AudioSource>().isPlaying) {
                    GameSounds.GetComponent<AudioSource>().Stop();
                }
                GameSounds.GetComponent<AudioSource>().PlayOneShot(AudioEstagio2, 0.18f);
            }
            MakeSoundEstagio2 = 1;
            MakeSoundEstagio1 = 0;
        }
    }

    public void DesactiveObjects(string objeto) {


        if (objeto.Equals("markerDefesa"))
        {
            Shield.tag = "Desativado";
        }
        else if (objeto.Equals("Swords"))
        {

            Attack.tag = "Desativado";
        }
        else if (objeto.Equals("markerPower"))
        {

            Power.tag = "Desativado";
        }

    }

    public void LostTracking(string namePlayer) {

        if (namePlayer == "Warrior")
        {
            Guerreira.tag = "Guerreira";

        }
        else if (namePlayer == "Hero")
        {

            Heroi.tag = "Heroi";
        }
        else if (namePlayer == "Shield")
        {
            Skeleton.tag = "Skeleton";

        }

    }

    public void ChangePlayer(string namePlayer) {

        if (namePlayer == "Warrior")
        {

            if (Heroi.tag == "PlayerOne" || Skeleton.tag == "PlayerOne")
            {

                Guerreira.tag = "PlayerTwo";
                GetComponent<AudioSource>().PlayOneShot(SelectPlayerTwo, 0.3f);
            }
            else if (Heroi.tag == "PlayerTwo" || Skeleton.tag == "PlayerTwo")
            {
                Guerreira.tag = "PlayerTwo";
                GetComponent<AudioSource>().PlayOneShot(SelectPlayerTwo, 0.3f);
                
            }
            else {
                Guerreira.tag = "PlayerOne";
                GetComponent<AudioSource>().PlayOneShot(SelectPlayerOne, 0.3f);
            }

        }
        else if (namePlayer == "Hero")
        {

            if (Guerreira.tag == "PlayerOne" || Skeleton.tag == "PlayerOne")
            {

                Heroi.tag = "PlayerTwo";
                GetComponent<AudioSource>().PlayOneShot(SelectPlayerTwo, 0.3f);
                
            }
            else if (Guerreira.tag == "PlayerTwo" || Skeleton.tag == "PlayerTwo")
            {
                Heroi.tag = "PlayerTwo";
                GetComponent<AudioSource>().PlayOneShot(SelectPlayerTwo, 0.3f);
                
            }
            else {
                Heroi.tag = "PlayerOne";
                GetComponent<AudioSource>().PlayOneShot(SelectPlayerOne, 0.3f);

            }
            
        } else  if(namePlayer == "Shield")
        {

            if (Guerreira.tag == "PlayerOne" || Heroi.tag == "PlayerOne")
            {

                Skeleton.tag = "PlayerTwo";
                GetComponent<AudioSource>().PlayOneShot(SelectPlayerTwo, 0.3f);
            }
            else if (Guerreira.tag == "PlayerTwo" || Heroi.tag == "PlayerTwo")
            {
                Skeleton.tag = "PlayerTwo";
                GetComponent<AudioSource>().PlayOneShot(SelectPlayerTwo, 0.3f);
                
            }
            else {
                Skeleton.tag = "PlayerOne";
                GetComponent<AudioSource>().PlayOneShot(SelectPlayerOne, 0.3f);

            }

        }



    }
    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }

    #endregion // PRIVATE_METHODS
}
