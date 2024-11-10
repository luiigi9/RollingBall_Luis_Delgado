using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Rigidbody rbB;
    int cantidadRings = 0;
    [SerializeField] TMP_Text textRings;
    [SerializeField] AudioClip sonido;
    [SerializeField] AudioManager audioManager;
    [SerializeField] int impulseForce;
    [SerializeField] LayerMask layerMask;
    RaycastHit hit;
    [SerializeField] private float dectSuelo;

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
            if (DetectarSuelo() == true)
            {
                rbB.AddForce(new Vector3(0f, 1f, 0f) * 5, ForceMode.Impulse);
            }
            
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
            audioManager.ReproducirSonido(sonido);
            Destroy(other.gameObject);
            cantidadRings++;
            textRings.SetText("Rings: " + cantidadRings);
        }
        if (other.gameObject.CompareTag("Badnik"))
        {
            cantidadRings -= 10;
            Destroy(other.gameObject);
            if (cantidadRings <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (other.gameObject.CompareTag("ImpulsePltfrm"))
        {
            rbB.AddForce(new Vector3(0f, 0f, 1f) * impulseForce, ForceMode.Impulse);
        }
        if (other.gameObject.CompareTag("Final"))
        {
            SceneManager.LoadScene(2);
        }
        if (other.gameObject.CompareTag("Restart"))
        { 
            SceneManager.LoadScene(1);
        }
        


    }
    bool DetectarSuelo()
    {

        bool detectado = Physics.Raycast(transform.position, new Vector3(0, -1, 0) , dectSuelo, layerMask);
        return detectado;
    }
}
