using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformV2 : MonoBehaviour
{
    Vector3 direccion = new Vector3(0, 1, 0);
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(direccion * 3 * Time.deltaTime, Space.World);
        if (timer >= 6)
        {
            direccion.y = direccion.y * -1;
            timer = 0;
        }
    }
}
