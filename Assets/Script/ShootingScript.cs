using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    
    public GameObject particleSystemToSpawn;
    public Transform spawnPoint;
    public AudioSource source;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //TODO Shooting logic
            Instantiate(particleSystemToSpawn, spawnPoint.position, spawnPoint.rotation);
            source.Play();
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //What you call here when your ray hits something
                if (hit.collider.CompareTag("Target"))
                {
                    TargetComponent tc = hit.collider.gameObject.GetComponent<TargetComponent>();
                    if (tc != null)
                    {
                        tc.ProcessHit();
                    }

                }
            }
        }
        
    }
}
