using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMuro : MonoBehaviour
{
    private float timer = 0f;
    private bool switcher = false;
    [SerializeField] Rigidbody[] rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (switcher == true)
        {
            timer += Time.unscaledDeltaTime;
            if (timer >= 2)
            {
                Time.timeScale = 1f;
                for (int i = 0; i < rb.Length; i++) 
                {
                    rb[i].useGravity = true;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Time.timeScale = 0.2f;
            switcher = true;
        }
    }
}
