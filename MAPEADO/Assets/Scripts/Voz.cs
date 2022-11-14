using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Windows.Speech;
using System.Linq;

using UnityEngine.SceneManagement;

public class Voz : MonoBehaviour
{
     KeywordRecognizer keywordRecognizer;
Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public float tiempo_start=0; 
         public  float tiempo_end=4; 
    void Start()
    {
        
       
        keywords.Add("jugar", () =>
{
   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    Debug.Log("se escucha");
    WindowsVoice.speak("Entrando al juego",5);
});
    keywords.Add("salir", () =>
{
  Application.Quit();
    Debug.Log("Saliendo");
    WindowsVoice.speak("Saliendo del juego",2);
    
});

keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
keywordRecognizer.Start();
    }

       
    void Update()
    {
          
    }
     private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
{
    System.Action keywordAction;
    // if the keyword recognized is in our dictionary, call that Action.
    if (keywords.TryGetValue(args.text, out keywordAction))
    {
        keywordAction.Invoke();
    }
}

    public void Play(AudioSource play)
    {
         
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        play.Play();
        Debug.Log("Jugando");
        WindowsVoice.speak("Entrando al juego",5);
        /*
        tiempo_start += Time.deltaTime;//Función para que la variable tiempo_start vaya contando segundos.
        if (tiempo_start != tiempo_end) //Si pasan los segundos que hemos puesto antes...
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/
    }
    public void Salir(AudioSource salir)
    {
        salir.Play();
        Application.Quit();
        Debug.Log("Saliendo");
    WindowsVoice.speak("saliendo del juego",2);

    }
}
