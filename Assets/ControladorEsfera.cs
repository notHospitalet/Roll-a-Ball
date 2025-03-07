using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControladorEsfera : MonoBehaviour
{

    public float speed;
    private int count;
    public Text text;
    public Text winText;
    
    private void Start()
    {
        count = 0;
        updateCounter();
        
        winText.text = "";
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        
        GetComponent<Rigidbody>().AddForce(direction * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pickup") {
            Destroy(other.gameObject);
            
            count++;
            updateCounter();
        }
    }

    void updateCounter()
    {
        text.text = "Puntos: " + count;
        
        int numPickups = GameObject.FindGameObjectsWithTag("pickup").Length;

        if (numPickups == 1)
        {
            winText.text = "WIN!";
        }
    }
}
