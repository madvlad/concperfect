using UnityEngine;
using System.Collections;

public class Concer : MonoBehaviour {

    public GameObject concPrefab;
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Conc"))
        {
            if (concPrefab)
            {
                GameObject newConc = Instantiate(concPrefab, transform.position + transform.forward, transform.rotation) as GameObject;

                if (!newConc.GetComponent<Rigidbody>()) { newConc.AddComponent<Rigidbody>(); }

                newConc.GetComponent<Rigidbody>().AddForce(transform.forward * 8, ForceMode.Impulse);
            }
        }
	}
}
