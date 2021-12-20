using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Level))]
public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] models;
    [SerializeField] private GameObject winningModel;
    [SerializeField] private UnityEvent<GameObject> WinningPlatformCreated;
    [SerializeField] private GameObject Level;
    private Level level;
    private GameObject[] currentLevelModels = new GameObject[4];
    private GameObject temporaryModel, temporaryWinningModel;
    private int currentLevelAddon = 7;
    private float i = 0;
    private void Awake() {
        level=Level.GetComponent<Level>();
    }
    private void Start()
    {
        //Selecting all models from inspector
        ModelSelection();
        //Instantiating different difficulty models
        for (i = 0; i > -level.CurrentLevel - currentLevelAddon; i -= 0.5f)
        {
            if (level.CurrentLevel <= 20)
            {
                ModelInstantiating(0, 2, 20);
            }
            else if (level.CurrentLevel > 20 && level.CurrentLevel <= 50)
            {
                ModelInstantiating(1, 3, 30);
            }
            else if (level.CurrentLevel > 50 && level.CurrentLevel <= 100)
            {
                ModelInstantiating(2, 4, 40);
            }
            else if (level.CurrentLevel > 100)
            {
                ModelInstantiating(3, 4, 60);
            }
        }
        temporaryWinningModel = Instantiate(winningModel);
        temporaryWinningModel.transform.position = new Vector3(0, i - 0.01f, 0);
        WinningPlatformCreated?.Invoke(temporaryWinningModel);
    }

    private void ModelInstantiating(int minModelRange, int maxModelRange, int maxRandomPercentage)
    {
        temporaryModel = Instantiate(currentLevelModels[Random.Range(minModelRange, maxModelRange)]);
        temporaryModel.transform.position = new Vector3(0, i - 0.01f, 0);
        temporaryModel.transform.eulerAngles = new Vector3(0, i * 8, 0);
        if (Random.Range(1, 101) <= maxRandomPercentage)
        {
            
            temporaryModel.transform.eulerAngles += Vector3.up * 180;
        }
        temporaryModel.transform.parent = Level.transform;
    }
    private void ModelSelection()
    {
        int randomModel = Random.Range(0, 5);

        switch (randomModel)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    currentLevelModels[i] = models[i];
                }
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    currentLevelModels[i] = models[i + 4];
                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    currentLevelModels[i] = models[i + 8];
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    currentLevelModels[i] = models[i + 12];
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    currentLevelModels[i] = models[i + 16];
                }
                break;
        }

    }
}
