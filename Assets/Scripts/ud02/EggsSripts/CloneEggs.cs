using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CloneEggs : MonoBehaviour
{
    //Ejercicio: click mousse en la gallina y pone un huevo
    //Necesito variable en la consola para decir QUÉ clono ("Egg")
    //Necesito otra variable tipo "transform" para decir DÓNDE tiene que aparecer
    //ésta será del "GameObject empty" que coloco y hago hijo del padre (la gallina)

    //Creo método y lo llamo desde el update 
    //Necesito un condicional para dar la orden al botón del ratón
    //Utilizo el "Instantiate ()" con el GameObject y el "Transform"
    //No necesito imprimirle fuerza  a los "Eggs" (solo gravedad) 
    //los huevos se eliminan pasado un tiempo; necesito esta variable tipo float

    //los huevos se eliminan pasado un tiempo; necesito variable float


    //Zona de variables globales
    //podria "SerializaField" y privadas
    public GameObject Egg;
    public Transform PosRotEgg;

    private float timeEggs = 6.0f;


    // Update is called once per frame
    void Update()
    {

      CreateEggsWithMouse(); 
  
    }

    private void CreateEggsWithMouse()
    { 

        if (Input.GetMouseButtonDown(0))
        {
           GameObject CloneEggs= Instantiate(Egg,PosRotEgg.position, PosRotEgg.rotation);
           Destroy(CloneEggs, timeEggs);

        }
    
}


}
