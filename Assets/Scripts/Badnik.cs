using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badnik : MonoBehaviour
{
    [SerializeField] Vector3 direccion;
    [SerializeField] int velocidad;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(direccion * velocidad * Time.deltaTime);
        if (timer >= 5)
        {
            direccion.z = direccion.z * -1;
            timer = 0;
        }
    }
}
