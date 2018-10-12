using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    public AudioClip playBeep;
    public AudioSource beepSfx;

    public GameObject burstPrefab;

	// Use this for initialization
	void Start () {
        beepSfx.clip = playBeep;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonUp(0)) {
            beepSfx.Play();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
            {
                Instantiate(burstPrefab, transform.position, Quaternion.identity);
            }
        }
	}
}
