using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Windows.Speech;
using System.Linq;

using UnityEngine.SceneManagement;

using System;

public class gameOver : MonoBehaviour
{
     KeywordRecognizer keywordRecognizer;
Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    [SerializeField] private GameObject menuGameOver;
    public _Player combateJugador;

    void Start()
    {
    combateJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<_Player>();
    combateJugador.MuertePlayer += ActivarMenu;
       
        keywords.Add("jugar", () =>
{
   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        play.Play();
        Debug.Log("Jugando");


    }
    public void Salir(AudioSource salir)
    {
        salir.Play();
        Application.Quit();
        Debug.Log("Saliendo");


    }
    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    private void ActivarMenu(object sender, EventArgs e) 
        {
            menuGameOver.SetActive(true);
        }
}
