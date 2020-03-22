using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxSpeed;

    Animator animator;
    Text itemNameText;

    void Awake()
    {
        itemNameText = GameObject.Find("ItemName").GetComponent<Text>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {      
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float movementInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movementInput * maxSpeed, rb.velocity.y);
        float x = Mathf.Clamp(transform.position.x, -6.5f, float.MaxValue);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 1);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
        }

        animator.SetFloat("speed", Mathf.Abs(movementInput));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (!collision.GetComponent<Interactive>().deactivated)
        {
            itemNameText.text = GetItemName(collision);
        } else
        {
            itemNameText.text = "";
        }

        if (!Input.GetKeyDown("space")) return;
        switch (GetItemName(collision))
        {
            case "Elevator Button":
                collision.GetComponent<ElevatorButton>().TurnOn();
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (itemNameText.text == GetItemName(collision))
            itemNameText.text = "";
    }

    private string GetItemName(Collider2D collision)
    {
        return Regex.Replace(collision.gameObject.name, "(\\B[A-Z])", " $1");
    }
}
