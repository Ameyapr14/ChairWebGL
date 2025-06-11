using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] public CameraOrbit Camref;
    [SerializeField] public Camera Cam;
    [SerializeField] public GameObject[] Objs;
    [SerializeField] public Button[] UIButtons;
    int count;

    private void Start()
    {
        count = 0;
        for (int i = 0; i < Objs.Length; i++)
        {
            Objs[i].SetActive(false);
        }
        for (int i = 0; i < UIButtons.Length; i++)
        {
            UIButtons[i].interactable = false;
        }
        UIButtons[0].interactable = true;
        Objs[0].SetActive(true);
    }

    public void Next()
    {
        if (count < 3)
        {
            UIButtons[1].interactable = true;
            Objs[count].SetActive(false);
            Objs[count+1].SetActive(true);
            Camref.target = Objs[count+1].transform;
            count++;
            if (count == 2)
            {
                UIButtons[0].interactable = false;
                UIButtons[1].interactable = true;
            }
        }
    }

    public void Previous()
    {
        if (count > 0)
        {
            UIButtons[0].interactable = true;
            Objs[count].SetActive(false);
            Objs[count - 1].SetActive(true);
            Camref.target = Objs[count - 1].transform;
            count--;
            if (count == 0)
            {
                UIButtons[1].interactable = false;
                UIButtons[0].interactable = true;
            }
        }
    }
}
