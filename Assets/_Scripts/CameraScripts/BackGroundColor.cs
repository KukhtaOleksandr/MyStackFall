using UnityEngine;

public class BackGroundColor : MonoBehaviour
{
    private Color [] colors = new Color[7];
    private void Awake() {
        
        
    }
    public void OnPlayerColorSet(int id)
    {
        colors[0]=new Color(0.67f,0.764f,0.18f);
        colors[1]=new Color(0.9f,0.87f,0.30f);
        colors[2]=new Color(0.94f,0.8f,0.2f);
        colors[3]=new Color(1,0.72f,0.56f);
        colors[4]=new Color(0.13f,0.91f,1);
        colors[5]=new Color(0.92f,0.70f,0.94f);
        colors[6]=new Color(0.73f,0.83f,0.99f);
        if(id<colors.Length)
        Camera.main.backgroundColor=colors[id];
    }

}
