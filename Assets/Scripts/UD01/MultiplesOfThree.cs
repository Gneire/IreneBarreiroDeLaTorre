using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EJERCICIO: muestra los múltiples del 3, del 0 al 100.
//Necesito bucle que recorra los números del 0 al 100 + condicional que seleccione solo los múltiples de 3.
//Múltiples de 3--> % 3 == 0)


public class MultiplesOfThree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //LLamo al método
        GetMultiplesNumbersOf3From0To100();

    }

    private void GetMultiplesNumbersOf3From0To100()
    {
        //Declaro, inicializo la  variable de incremento "i" y pongo contador dentro ya del "for" 
        for (int i = 0; i < 101; i++)
        {
            if (i % 3 == 0)
            {
                Debug.Log(i);
            }
        }
    }
}
