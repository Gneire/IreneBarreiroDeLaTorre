using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EJERCICIO: muestra los m�ltiples del 3, del 0 al 100.
//Necesito bucle que recorra los n�meros del 0 al 100 + condicional que seleccione solo los m�ltiples de 3.
//M�ltiples de 3--> % 3 == 0)


public class MultiplesOfThree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //LLamo al m�todo
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
