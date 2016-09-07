using UnityEngine;
using System.Collections;

public class Concer : MonoBehaviour {

    public GameObject concPrefab;
    private bool primed = false;
    private float timer = 4.0f;
    private GameObject concInstance;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Conc"))
        {
            primed = true;
            concInstance = Instantiate(concPrefab, transform.position, transform.rotation) as GameObject;
            if (!concInstance.GetComponent<Rigidbody>()) { concInstance.AddComponent<Rigidbody>(); }
            concInstance.GetComponent<Rigidbody>().useGravity = false;
            concInstance.GetComponent<BoxCollider>().enabled = false;
            concInstance.GetComponent<MeshRenderer>().enabled = false;
        }
	    if (primed && !Input.GetButton("Conc"))
        {
            if (concPrefab && !concInstance.GetComponent<Conc>().exploded)
            {
                concInstance.transform.position = transform.position + transform.forward;
                concInstance.GetComponent<BoxCollider>().enabled = true;
                concInstance.GetComponent<MeshRenderer>().enabled = true;
                concInstance.GetComponent<Rigidbody>().useGravity = true;
                concInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 8, ForceMode.Impulse);
                primed = false;
            }
        } else if (primed)
        {
            concInstance.transform.position = transform.position;
        }
	}
}
