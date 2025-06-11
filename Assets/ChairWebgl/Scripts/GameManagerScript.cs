using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] public CameraOrbit Camref;
    [SerializeField] public Camera Cam;
    [SerializeField] public GameObject[] Objs;
    [SerializeField] public Button[] UIButtons;
    [SerializeField] public GameObject[] BGObjs;
    [SerializeField] public Button[] UIButtonsBG;
    int count;

    private void Start()
    {
        count = 0;
        for (int i = 0; i < Objs.Length; i++)
        {
            Objs[i].SetActive(false);
        }

        for (int i = 0; i < BGObjs.Length; i++)
        {
            BGObjs[i].SetActive(false);
        }

        for (int i = 0; i < UIButtons.Length; i++)
        {
            UIButtons[i].interactable = false;
        }
        UIButtons[0].interactable = true;

        for (int i = 0; i < UIButtonsBG.Length; i++)
        {
            UIButtonsBG[i].interactable = false;
        }
        UIButtonsBG[0].interactable = true;
        Objs[0].SetActive(true);
        BGObjs[0].SetActive(true);
    }

    public void NextObj()
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

    public void PreviousObj()
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

    public void NextBG()
    {
        UIButtonsBG[0].interactable = false;
        UIButtonsBG[1].interactable = true;
        BGObjs[0].SetActive(false);
        BGObjs[1].SetActive(true);
    }

    public void PreviousBG()
    {
        UIButtonsBG[1].interactable = false;
        UIButtonsBG[0].interactable = true;
        BGObjs[1].SetActive(false);
        BGObjs[0].SetActive(true);
    }


}
