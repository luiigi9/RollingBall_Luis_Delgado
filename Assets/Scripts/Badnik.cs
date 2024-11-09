using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badnik : MonoBehaviour
{
    [SerializeField] Vector3 direccion;
    [SerializeField] float velocidad;
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
        if (timer >= 2)
        {
            direccion.y = direccion.y * -1;
            timer = 0;
        }
    }
}
