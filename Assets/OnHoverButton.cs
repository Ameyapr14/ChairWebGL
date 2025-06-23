using UnityEngine;
using UnityEngine.UI;

public class OnHoverButton : MonoBehaviour
{
    [SerializeField] private Text Text;
    [SerializeField] private GameObject bar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Text.GetComponent<GameObject>();

    }

    public void OnHoverEnter()
    {
        Text.transform.position = new Vector3 (transform.position.x + 5, transform.position.y, transform.position.z);
        bar.SetActive(true);
    }

    public void OnHoverExit()
    {
        bar.SetActive(false);
        Text.transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
    }

    public void ONPRESSED()
    {
        Debug.Log("HI i am pressed");
    }
}
