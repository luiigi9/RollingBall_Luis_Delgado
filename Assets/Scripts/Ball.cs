using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
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
        direccionB.x = h;
        rbB.AddForce(direccionB.normalized * 2, ForceMode.Force);

    }
}
