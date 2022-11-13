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


    void Start()
    {
        
       
        keywords.Add("jugar", () =>
{
   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    Debug.Log("se escucha");
});
    keywords.Add("salir", () =>
{
  Application.Quit();
    Debug.Log("Saliendo");
    
    
});

keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
keywordRecognizer.Start();
    }

    // Update is called once per frame
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


    }
    public void Salir(AudioSource salir)
    {
        salir.Play();
        Application.Quit();
        Debug.Log("Saliendo");


    }
}
