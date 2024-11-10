using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCam2 : MonoBehaviour
{
    [SerializeField] private GameObject cam1;
    [SerializeField] private GameObject camloop;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            camloop.SetActive(false);
            cam1.SetActive(true);

        }
    }
}
