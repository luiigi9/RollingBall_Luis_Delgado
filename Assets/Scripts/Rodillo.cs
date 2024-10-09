using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodillo : MonoBehaviour
{
    [SerializeField] Vector3 rotacion;
    [SerializeField] int fuerza;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(rotacion * fuerza, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
