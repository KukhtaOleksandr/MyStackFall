using UnityEngine;
using UnityEngine.UI;

public class GameUIColors : MonoBehaviour
{
    [Header("InGame")]
    [SerializeField]private Image levelSlider;
    [SerializeField]private Image currentLevelImg;
    [SerializeField]private Image nextLevelImg;
    private Color playerColor;
    private void Awake() {
        playerColor = FindObjectOfType<Player>().transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
    }
    private void OnEnable() {
        levelSlider.transform.parent.GetComponent<Image>().color=playerColor+Color.gray;
        levelSlider.color=playerColor;
        currentLevelImg.color=playerColor;
        nextLevelImg.color=playerColor;
        
    }

}
