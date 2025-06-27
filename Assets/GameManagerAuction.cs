using StarterAssets;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManagerAuction : MonoBehaviour
{
    [SerializeField] private GameObject[] ItemSelection;
    [SerializeField] private GameObject[] InfoButtons;
    [SerializeField] private GameObject[] InfoPanels;
    [SerializeField] private GameObject[] ArtifactPos;
    [SerializeField] private string url = "https://www.youtube.com/watch?v=6WzU6jmXNIY";

    private void Start()
    {
        for (int i = 0; i < ItemSelection.Length; i++)
        {
            ItemSelection[i].SetActive(false);
        }

        for (int i = 0; i < InfoButtons.Length; i++)
        {
            InfoButtons[i].SetActive(true);
            InfoPanels[i].SetActive(false);
        }
    }

    public void ItemSelected(int no)
    {
        if( no== 0)
        {
            ItemSelection[0].SetActive(true);
            ItemSelection[1].SetActive(false);
            ItemSelection[2].SetActive(false);
        }
        else if (no == 1)
        {
            ItemSelection[0].SetActive(false);
            ItemSelection[1].SetActive(true);
            ItemSelection[2].SetActive(false);
        }
        else if (no == 2)
        {
            ItemSelection[0].SetActive(false);
            ItemSelection[1].SetActive(false);
            ItemSelection[2].SetActive(true);
        }
    }

    public void InfoButtonPressed(int no)
    {
        if(no == 0)
        {
            ResetCall();
            InfoButtons[0].SetActive(false);
            InfoPanels[0].SetActive(true);
        }
        else if(no == 1)
        {
            ResetCall();
            InfoButtons[1].SetActive(false);
            InfoPanels[1].SetActive(true);
        }
        else if(no == 2)
        {
            ResetCall();
            InfoButtons[2].SetActive(false);
            InfoPanels[2].SetActive(true);
        }
    }

    public void ResetCall()
    {
        for (int i = 0; i < InfoButtons.Length; i++)
        {
            InfoButtons[i].SetActive(true);
            InfoPanels[i].SetActive(false);
        }
    }

    public void OnClick()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=6WzU6jmXNIY");
    }

    public void ResetPosition()
    {
        for(int i = 0; i<ArtifactPos.Length;i++)
        {
            ArtifactPos[i].transform.rotation = Quaternion.Euler(0,90,0);
        }
    }
}
