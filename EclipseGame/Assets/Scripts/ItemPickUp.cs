using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject WrenchOnPlayer;
    // Start is called before the first frame update
    void Start()
    {
        WrenchOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    /*void Update() 
    {
        onTriggerStay();
    }*/

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            PickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E)) {
                this.gameObject.SetActive(false);
                WrenchOnPlayer.SetActive(true);

                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }
}
