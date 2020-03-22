
using UnityEngine;

public class Masks : MonoBehaviour
{
    public void Wear()
    {
        FindObjectOfType<Player>().transform.Find("Mask").gameObject.SetActive(true);
        GetComponent<Interactive>().Deactivate();
    }
}
