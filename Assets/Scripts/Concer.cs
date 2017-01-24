using UnityEngine;
using System.Collections;

public class Concer : MonoBehaviour {

    public GameObject concNotification;
    public GameObject concPrefab;
    private bool primed = false;
    private float timer = 0.0f;
    private float explosionTimer = 0.0f;
    private GameObject concInstance;
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (explosionTimer > 0)
        {
            explosionTimer -= Time.deltaTime;
        } else
        {
            concNotification.SetActive(false);
        }

        if (Input.GetButtonDown("Conc"))
        {
            if (timer <= 0)
            {
                timer = 0.45f;
                SetPrime(true);
                concInstance = Instantiate(concPrefab, transform.position, transform.rotation) as GameObject;
                explosionTimer = 4.0f;
                if (!concInstance.GetComponent<Rigidbody>()) { concInstance.AddComponent<Rigidbody>(); }
                WillInteractWithWorld(false);
            }
        }
	    if (primed && !Input.GetButton("Conc"))
        {
            if (concInstance == null) { SetPrime(false); return; }
            if (concPrefab && !concInstance.GetComponent<Conc>().exploded)
            {
                concInstance.transform.position = transform.position + transform.forward;
                WillInteractWithWorld(true);
                concInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 8, ForceMode.Impulse);
                SetPrime(false);
            }
        } else if (primed)
        {
            concInstance.transform.position = transform.position;
        }
	}

    private void WillInteractWithWorld(bool enabled)
    {
        concInstance.GetComponent<BoxCollider>().enabled = enabled;
        concInstance.GetComponent<MeshRenderer>().enabled = enabled;
        concInstance.GetComponent<Rigidbody>().useGravity = enabled;
    }

    private void SetPrime(bool prime)
    {
        concNotification.SetActive(prime);
        primed = prime;
    }
}
