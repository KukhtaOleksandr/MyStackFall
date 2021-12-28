using UnityEngine;
using UnityEngine.UI;

public class GameUIColors : MonoBehaviour
{
    [SerializeField]private Material playerMaterial;

    [Header("InGame")]
    [SerializeField]private Image levelSlider;
    [SerializeField]private Image currentLevelImg;
    [SerializeField]private Image nextLevelImg;
    

    public void OnPlayerColorSet(int id)
    {
        
        levelSlider.transform.parent.GetComponent<Image>().color=playerMaterial.color+new Color(0.2f,0.2f,0.2f,1);
        levelSlider.color=playerMaterial.color+new Color(-0.1f,-0.1f,0.1f,1);
        currentLevelImg.color=playerMaterial.color+new Color(0,0,0,1);
        nextLevelImg.color=playerMaterial.color+new Color(0,0,0,1);
        if(id==1||id==0)
        {
            currentLevelImg.transform.GetChild(0).GetComponent<Text>().color=new Color(0.311f,0.311f,0.311f,1);
            nextLevelImg.transform.GetChild(0).GetComponent<Text>().color=new Color(0.311f,0.311f,0.311f,1);
        }
        else
        {
            currentLevelImg.transform.GetChild(0).GetComponent<Text>().color=Color.white;
            nextLevelImg.transform.GetChild(0).GetComponent<Text>().color=Color.white;
        }
    }

}
