using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    public GameObject shotPrefab;
    public Transform[] firePoints;
    private int firePointIndex;

    public void Awake()
    {
        InputManager.instance.SetWeapons(this);
    }

    public void OnDestroy()
    {
        if (Application.isPlaying == true)
        {
            InputManager.instance.RemoveWeapons(this);
        }
        else
        {
            return;
        }
    }

    public void Fire()
    {
        if (firePoints.Length == 0)
        {
            return;
        }

        var firePointToUse = firePoints[firePointIndex];
        Instantiate(shotPrefab, firePointToUse.position, firePointToUse.rotation);
        var audio = firePointToUse.GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }

        firePointIndex++;
        
        if (firePointIndex >= firePoints.Length)
        {
            firePointIndex = 0;
        }
    }


}
