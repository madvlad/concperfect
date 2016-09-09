using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
    public GameObject destination;
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = destination.transform.position;

        }
    }
}
