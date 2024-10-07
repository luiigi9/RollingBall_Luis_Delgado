using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] int vidas = 100;
    Rigidbody rbB;

    Vector3 direccionB = new Vector3 (0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        rbB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space)) {
            rbB.AddForce(new Vector3(0f, 1f, 0f) * 5, ForceMode.Impulse);
        }
        direccionB.z = v;
        direccionB.x = h * 2;
        

    }
    private void FixedUpdate() //Ciclo pensado para fisicas continuas
    {
        rbB.AddForce(direccionB.normalized * 2, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ring"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Badnik"))
        {
            vidas -= 10;
            Destroy(other.gameObject);
            if (vidas <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
