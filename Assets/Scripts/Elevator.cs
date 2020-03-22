using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Sprite elevator;
    public Sprite elevatorEmpty;
    public Sprite elevatorFull;

    int count = 0;

    SpriteRenderer spriteRenderer;
    Interactive interactive;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactive = GetComponent<Interactive>();
    }

    public void Arrive()
    {
        interactive.Activate();
        if (count == 0)
        {
            spriteRenderer.sprite = elevatorFull;
        } else
        {
            spriteRenderer.sprite = elevatorEmpty;
        }

        count++;
    }

    public void Close()
    {
        spriteRenderer.sprite = elevator;
        interactive.Deactivate();
    }
}
