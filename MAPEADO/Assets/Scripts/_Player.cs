using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Player : MonoBehaviour
{
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
    public GameObject sfx;
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
    private void FixedUpdate()
    {
        velocity = Vector3.Distance(current_pos, last_pos);
        if (velocity >= velocity_mov)
        {
            _Sfx(true);
        }
        else
        {
            _Sfx(false);
        }
        Debug.Log(velocity);
        last_pos = current_pos;
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
        audios = sfx.GetComponents<AudioSource>();
        int num;
        num = Random.Range(0, audios.Length);

        if (_play == false)
        {
            audios[0].Pause();

        }
        //velocity = Vector3.Distance(current_pos, last_pos);
        if (_play==true && !audios[0].isPlaying)
        {
            audios[0].Play();
        }

        /*if (velocity>=velocity_mov && !audios[0].isPlaying)
        {
            audios[0].Play();
        }
       /* else
        {
            audios[0].Pause();

        }*/


        /*for (int i = 0; i < audios.Length; i++)
        {
            audios[0].Pause();

        }*/



    }
}

