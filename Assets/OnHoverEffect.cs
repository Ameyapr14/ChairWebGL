using UnityEngine;
using UnityEngine.UI;

public class OnHoverEffect : MonoBehaviour
{
    [SerializeField] private Text Text;
    [SerializeField] private GameObject bar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Text.GetComponent<Text>();
        
    }

    public void OnHoverEnter()
    {
        Text.GetComponent<Text>().fontSize = 15;
        bar.SetActive(true);
    }

    public void OnHoverExit()
    {
        bar.SetActive(false);
        Text.GetComponent<Text>().fontSize = 14;
    }

}
