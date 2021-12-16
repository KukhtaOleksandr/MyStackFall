using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] models;
    [SerializeField] private GameObject winningModel;
    [SerializeField] private UnityEvent<GameObject> WinningPlatformCreated;
    [SerializeField] private GameObject Level;
    private GameObject[] currentLevelModels = new GameObject[4];
    private GameObject temporaryModel, temporaryWinningModel;
    private int currentLevel = 1,currentLevelAddon=7;
    private float i=0;

    private void Start()
    {
        //Selecting all models from inspector
        ModelSelection();
        //Instantiating different difficulty models
        for (i = 0; i > -currentLevel-currentLevelAddon; i-=0.5f)
        {
            if (currentLevel <= 20)
                temporaryModel = Instantiate(currentLevelModels[Random.Range(0, 2)]);
            if (currentLevel > 20 && currentLevel <= 50)
                temporaryModel = Instantiate(currentLevelModels[Random.Range(1, 3)]);
            if (currentLevel > 50 && currentLevel <= 100)
                temporaryModel = Instantiate(currentLevelModels[Random.Range(2, 4)]);
            if (currentLevel > 100)
                temporaryModel = Instantiate(currentLevelModels[Random.Range(3, 4)]);

            temporaryModel.transform.position = new Vector3(0, i - 0.01f, 0);
            temporaryModel.transform.eulerAngles = new Vector3(0, i * 8, 0);
            temporaryModel.transform.parent=Level.transform;
        }
        temporaryWinningModel=Instantiate(winningModel);
        temporaryWinningModel.transform.position = new Vector3(0, i - 0.01f, 0);
        WinningPlatformCreated?.Invoke(temporaryWinningModel);
    }
    private void ModelSelection()
    {
        int randomModel=Random.Range(0,5);

        switch(randomModel)
        {
            case 0: 
            for(int i=0;i<4;i++)
            {
                currentLevelModels[i]=models[i];
            }
            break;
            case 1: 
            for(int i=0;i<4;i++)
            {
                currentLevelModels[i]=models[i+4];
            }
            break;
            case 2: 
            for(int i=0;i<4;i++)
            {
                currentLevelModels[i]=models[i+8];
            }
            break;
            case 3: 
            for(int i=0;i<4;i++)
            {
                currentLevelModels[i]=models[i+12];
            }
            break;
            case 4: 
            for(int i=0;i<4;i++)
            {
                currentLevelModels[i]=models[i+16];
            }
            break;
        }

    }
}
