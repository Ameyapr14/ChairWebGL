using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManagerAuction : MonoBehaviour
{

    /* [SerializeField] private GameObject[] ItemSelection;
     [SerializeField] private GameObject[] InfoButtons;
     [SerializeField] private GameObject[] InfoPanels;
     [SerializeField] private GameObject[] ArtifactPos;
     [SerializeField] private string url = "https://www.youtube.com/watch?v=6WzU6jmXNIY";*/
    [SerializeField] public GameObject playerPos;
    [SerializeField] public GameObject[] Info;
    [SerializeField] public GameObject[] ButtonsOn;
    [SerializeField] public GameObject[] ButtonsOff;
    [SerializeField] public PlaermovmentScript PlayerScript;
    [SerializeField] public GameObject Square;
    [SerializeField] public Camera Camera;
    [SerializeField] public bool Chair, Bag;
    [SerializeField] 
  

    public void TriggerSceneLoad()
    {
        
        SceneManager.LoadScene("3DView");
    }
    public void TriggerSceneFrameLoad()
    {

        SceneManager.LoadScene("3DViewFrame");
    }

    private void Start()
    {
        /* for (int i = 0; i < ItemSelection.Length; i++)
         {
             ItemSelection[i].SetActive(false);
         }

         for (int i = 0; i < InfoButtons.Length; i++)
         {
             InfoButtons[i].SetActive(true);
             InfoPanels[i].SetActive(false);
         }*/
        Chair = false;
        Bag = false;
     
        for (int i = 0; i < Info.Length; i++)
        {
            Info[i].SetActive(false);
            ButtonsOff[i].SetActive(false);
            ButtonsOn[i].SetActive(true);
        }
       
    }

    public void ResetPossqaure()
    {
        Square.transform.localPosition = new Vector3(-0.03f, -0.01f, 1.04f);
        Square.transform.rotation = Quaternion.Euler(0, -90, 0);
        Square.transform.localScale = new Vector3(0.27f, 0.27f, 0.27f);
    }

    /* public void ItemSelected(int no)
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
     }*/


    public void OnClick()
    {
        Application.OpenURL("https://onlineonly.christies.com/s/collections-including-orange-blossom-collection-works-centuries-taste/george-iii-mahogany-bergere-238/253185?ldp_breadcrumb=back");
    }


    public void RoomSelection(int num)
    {
        PlayerScript.enabled = false;
            if (num == 0)
            {
                 
                playerPos.transform.localPosition = new Vector3(-3.898942f, 1.08f, -7.075891f);
                playerPos.transform.rotation = Quaternion.Euler(0, -320.2f, 0);
            }
            else if (num == 1)
            {
                                      
                playerPos.transform.localPosition = new Vector3(3.22f, 1.08f, -0.0408675f);
                playerPos.transform.rotation = Quaternion.Euler(0, -449.9f, 0);
            }
            else if (num == 2)
            {
                 
                playerPos.transform.localPosition = new Vector3(-0.377f, 1.08f, -10.767f);
                playerPos.transform.rotation = Quaternion.Euler(0, -449.9f, 0);
            }
            else if (num == 3)
            {
                    
                 playerPos.transform.localPosition = new Vector3(0.5959f, 1.08f, 10.815f);
                playerPos.transform.rotation = Quaternion.Euler(0, -270.3f, 0);
            }
            else if (num == 4)
            {
               
                playerPos.transform.localPosition = new Vector3(-7.533f, 1.08f, 0.319f);
                playerPos.transform.rotation = Quaternion.Euler(0, -358, 0);
            }
            else if (num == 5)
            {
                
                playerPos.transform.localPosition = new Vector3(7.63f, 1.08f, 0.161f);
                playerPos.transform.rotation = Quaternion.Euler(0, -360, 0);
            }
            else if (num == 6)
            {
                
                playerPos.transform.localPosition = new Vector3(8.095207f, 1.08f, -0.1599064f);
                playerPos.transform.rotation = Quaternion.Euler(0, -270, 0);
                
            }
            else if (num == 7)
            {
                
                playerPos.transform.localPosition = new Vector3(-0.558396f, 1.08f, 11.49494f);
             playerPos.transform.rotation = Quaternion.Euler(0, -360, 0);
            
            }

        StartCoroutine(SatrtDelay());
       
    }

    IEnumerator SatrtDelay()
    {
        yield return new WaitForSeconds(1.2f);
        PlayerScript.enabled = true;
    }

    public void InfoPressed(int num)
    {
        if (num == 0)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if(num == 1)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 2)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 3)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 4)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 5)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 6)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 7)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 8)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 9)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 10)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 11)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 12)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 13)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 14)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 15)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 16)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
        else if (num == 17)
        {
            Info[num].SetActive(true);
            ButtonsOff[num].SetActive(true);
            ButtonsOn[num].SetActive(false);
        }
    }

    public void ClosePressed(int num)
    {
        if (num == 0)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 1)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 2)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 3)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 4)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 5)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 6)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 7)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 8)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 9)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 10)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 11)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 12)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 13)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 14)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 15)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 16)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
        else if (num == 17)
        {
            Info[num].SetActive(false);
            ButtonsOff[num].SetActive(false);
            ButtonsOn[num].SetActive(true);
        }
    }

    public void ChairBooleanPressed()
    {
        Chair=true;

    }

    public void BagBooleanPressed()
    {
        Bag = true;
    }
}
