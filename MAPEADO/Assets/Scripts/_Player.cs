using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;
using System.Linq;
public class _Player : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();



    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision) 
     {
        if(collision.gameObject.CompareTag("Enemigo"))
        {
           // Destroy(gameObject);
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }   
     }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("detect");
            WindowsVoice.speak("enemigo cerca");

    
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(other.gameObject);
                Debug.Log("pegando");
                WindowsVoice.speak("Atacando, enemigo eliminado");
            }

        }
    }

    /*
     private void OnTriggerStay(Collider other){

        if(other.gameObject.CompareTag("Enemigo")){
            if(Input.GetKeyDown(KeyCode.F)){
                Destroy(other);
               Debug.Log("pegando");
            }
            Debug.Log("detect");
        }
     }
*/
}

