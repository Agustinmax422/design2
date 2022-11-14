using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Windows.Speech;
using System.Linq;

public class Esfe : MonoBehaviour
{
       KeywordRecognizer keywordRecognizer;
Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public float speed = 30f;
    private new Rigidbody rigidbody;
    public float sensitivity = 2;
    public float smoothing = 1.5f;
    private Vector2 velocity_look;
    private Vector2 frameVelocity;
    float velocity_mov = .01f;
    private float velocity;
    private Vector2 current_pos => new Vector2(transform.position.x, transform.position.z);
   // private Vector2 current_pos;
    private Vector2 last_pos;
   
    private AudioSource[] audios;
    
   


    void Start()
    {

       


        Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
        //velocity = new Vector2(transform.position.x,transform.position.z);
        //_Sfx();
    }

    // Update is called once per frame
    void Update()
    {  
        _Move();
        _look();
        
   
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

    private void _Move()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        
        if (hor != 0.0f || ver != 0.0f)
        {
            
            
            Vector3 dir = transform.forward * ver + transform.right * hor;
            
            rigidbody.MovePosition(transform.position + dir * speed * Time.deltaTime);
        }
     
    }
    private void _look()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity_look += frameVelocity;
        transform.localRotation = Quaternion.AngleAxis(velocity_look.x, Vector3.up);
    }

    private void _Sfx(bool _play)
    {

    }
  
    
     private void OnTriggerStay(Collider other){

        if(other.gameObject.CompareTag("Enemigo")){
            Debug.Log("detect");
          WindowsVoice.speak("enemigo cerca");

/*
             keywords.Add("atacar", () =>
{
  
    Debug.Log("atacando");
    Destroy(other.gameObject);
    WindowsVoice.speak("Atacando",5);
});

keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
keywordRecognizer.OnTriggerStay(other); */

            if(Input.GetKeyDown(KeyCode.F)){
                Destroy(other.gameObject);
               Debug.Log("pegando");
                WindowsVoice.speak("Atacando, enemigo eliminado");
            }
            
        }
     }
}

