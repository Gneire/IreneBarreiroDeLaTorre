using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerTrigger : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider infoAccess)
    {
        Debug.Log("choqué con" + infoAccess.gameObject.name);
        if (infoAccess.CompareTag("Enemy"))
        {
            Destroy(infoAccess.gameObject);
        }
        
    }
}
