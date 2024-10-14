using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//EJERCICIO: mostrar los múltiplos (comunes) de 3 y de 2 ENTRE 0 y 100 (0 y 100 no incluidos)
//necesito un bucle que recorra los números del 1 al 99
// condicional que me seleccione los que quiero 
// (múltiples de 2 --> i % 2 == 0) (múltiples de 3 --> i % 3 == 0)

public class MultiplesOfThreeTwo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //LLamo al método
        GetMultiplesOf2And3From1To99();
    }

    private void GetMultiplesOf2And3From1To99()
    {
        //zona variables locales
        int multiplesNumbers = 0;
  
        //Declaro, inicializo la  variable de incremento "i" y pongo contador dentro ya del "for" 
        for (int i = 1; i < 100; i++)
        {
            if (i % 2 == 0)
            {
                multiplesNumbers = i;
            
                if (multiplesNumbers % 3 == 0)
                {
                    Debug.Log(multiplesNumbers);
                }

            }

        }
    }
    
}
