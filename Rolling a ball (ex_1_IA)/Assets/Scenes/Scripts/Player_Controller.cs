using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Controller : MonoBehaviour
{
    public float speed = 0.0f;
    public Text count_text;
    public Text win_text;

    private Rigidbody rb;
    private int count = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        win_text.text = "";
    }

    void FixedUpdate()
    {
        float Move_Horizontal = Input.GetAxis("Horizontal");
        float Move_Vertical = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(Move_Horizontal, 0.0f, Move_Vertical);

        rb.AddForce(Movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            if (count >= 12)
            {
                win_text.text = "YOU WIN!";
            }
        }
    }

    void SetCountText ()
    {
        count_text.text = "Count: " + count.ToString();
    }
}