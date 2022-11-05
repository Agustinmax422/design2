using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public GameObject tomaOstia;
    // Start is called before the first frame update
    void Start()
    {
        tomaOstia.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            tomaOstia.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            tomaOstia.SetActive(false);
        }
    }
}
    /*/
    void Start()
    {
        tomaOstia.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    public void Activo()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            tomaOstia.GetComponent<BoxCollider>().enabled = true;
            }else if(Input.GetKeyUp(KeyCode.P)){
            tomaOstia.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

*/