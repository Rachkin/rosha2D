using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerControllerScript : MonoBehaviour
{

    public float mv_speed;
    public float mv_sh_k;
    public float cr_speed;

    private Rigidbody rb;
    private Transform tr;
    //public Joystick joystick;
    private float last_time;
    private float now_time;

    public GameObject cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    void Update()
    {

        now_time = Time.time;
        float dif = (now_time - last_time) * 100;
        last_time = now_time;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        x = mv_speed * x * dif;
        y = mv_speed * y * dif;

        if (Input.GetAxis("Shift") > 0.5)
        {
            x = x * mv_sh_k;
            y = y * mv_sh_k;
            Debug.Log(Input.GetAxis("Shift"));
        }
        Vector3 movement = new Vector3(x, 0, y);
        rb.velocity = movement;

        cam.transform.position = (new Vector3(tr.position.x, tr.position.y + 10, tr.position.z));

    }
}
