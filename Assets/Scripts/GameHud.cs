using UnityEngine;

public class GameHud : MonoBehaviour
{
    private GameObject HUD {get => gameObject;}
    
    public void ShowHud(bool state)
    {
        HUD.SetActive(state);
        for (int i = 0; i < HUD.transform.childCount; i++)
        {
            HUD.transform.GetChild(i).gameObject.SetActive(state);
        }
    }
}
