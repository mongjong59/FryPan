using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxSpeed;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        DontDestroyOnLoad(gameObject);
    }

    void FixedUpdate()
    {      
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float movementInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movementInput * maxSpeed, rb.velocity.y);
        Vector3 position = transform.position;
        float x = position.x;
        if (CurrentSceneName() == "1Bedroom")
        {
            float clampedX = Mathf.Clamp(x, -6.5f, float.MaxValue);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }

        if (CurrentSceneName() == "4Hallway")
        {
            float clampedX = Mathf.Clamp(x, float.MinValue, 6.5f);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }

        if (x > 6.7f) LoadScene();
        if (x < -6.7f) LoadScene(true);

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
        if (!collision.GetComponent<Interactive>().deactivated)
        {
            ItemNameText().text = GetItemName(collision);
        } else
        {
            ItemNameText().text = "";
        }

        if (!Input.GetKeyDown("space")) return;
        switch (GetItemName(collision))
        {
            case "Elevator Button":
                collision.GetComponent<ElevatorButton>().TurnOn();
                break;
            case "Masks":
                collision.GetComponent<Masks>().Wear();
                break;
            default:
                break;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (ItemNameText().text == GetItemName(collision))
            ItemNameText().text = "";
    }

    string GetItemName(Collider2D collision)
    {
        return Regex.Replace(collision.gameObject.name, "(\\B[A-Z])", " $1");
    }

    string CurrentSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    Text ItemNameText()
    {
        return GameObject.Find("ItemName").GetComponent<Text>();
    }

    void LoadScene(bool previous = false)
    {
        List<string> SCENE_NAMES = new List<string> { "0Onboarding", "1Bedroom", "2LivingRoom", "3Kitchen", "4Hallway" };
        int i = SCENE_NAMES.IndexOf(CurrentSceneName());
        int newI;
        if (previous)
        {
            newI = i - 1;
        }
        else
        {
            newI = i + 1;
        }
        SceneManager.LoadScene(newI);
        if (previous)
        {
            transform.position = new Vector3(6.6f, transform.position.y, transform.position.z);
        } else
        {
            transform.position = new Vector3(-6.6f, transform.position.y, transform.position.z);
        }
    }
}
