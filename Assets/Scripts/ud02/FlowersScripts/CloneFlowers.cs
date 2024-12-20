using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneFlowers : MonoBehaviour
{



    //Zona de variables globales

    //Necesito variable en la consola para decir QU� clono ("Flower")
    //Necesito otra variable tipo "transform" para decir D�NDE tiene que aparecer
    public GameObject Flower;
    public Transform PosRotFlower;

    //creo las variables para imprimir fuerza ejes Y y Z
    //el ataque es parab�lico entonces mayor Y que Z
    //creo variable del tiempo que dura cada flor en la escena
    private float thrustY = 300.0f,
                  thrustZ = 100.0f,
                  timeFlowers = 8.0f;


    void Update()
    {

        CreateFlowersWithMouse();

    }

    //creo el m�todo que llamo en el Update
    private void CreateFlowersWithMouse()
    {
        //ordeno al bot�n izquierdo del rat�n que al cliquear haga...
        if (Input.GetMouseButtonDown(0))
        {
            //clone flores desde donde le mando
            GameObject CloneFlowers = Instantiate(Flower, PosRotFlower.position, PosRotFlower.rotation);

            //trabajo con el rigidbody de las flores clonadas
            Rigidbody rbFlowers = CloneFlowers.GetComponent<Rigidbody>();

            //le imprimo la fuerza en el eje Y
            rbFlowers.AddForce(Vector3.up * thrustY);

            //le imprimo la fuerza en el eje Z
            rbFlowers.AddForce(transform.forward * thrustZ);

            //Ordeno que las flores se destruyan despu�s de un tiempo
            Destroy(CloneFlowers, timeFlowers);

        }

    }


}

