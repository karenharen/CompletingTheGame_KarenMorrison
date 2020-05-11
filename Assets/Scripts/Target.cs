using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private GameManager gameManager;
    private EventManager eventManager;
    [SerializeField] private ParticleSystem explodeParticle;

    // Start is called before the first frame update
    void Start()
    {
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();

        targetRB = GetComponent<Rigidbody>();

        //randomly select launch location
        transform.position = new Vector3(Random.Range(-5,5),-5, 0);

        //randomly select the upward force
        targetRB.AddForce(Vector3.up * Random.Range(14,19), ForceMode.Impulse);

        //randomly select the spin force
        targetRB.AddTorque(Random.Range(-5,5), Random.Range(-5, 5), Random.Range(-5, 5), ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Instantiate(explodeParticle, transform.position, Quaternion.identity);
        if (CompareTag("bad"))
        {     
           eventManager.targetDestoryed?.Invoke(-7);
                 
        } else if (CompareTag("good"))
        {
        
            eventManager.targetDestoryed?.Invoke(7);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }


}
