using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectPlacer : MonoBehaviour
{
    public AllLetters CurrentLetter;
    [Space]
    [SerializeField] private GameObject nextLvl;
    [Space]
    [SerializeField] private GameObject[] objectPrefabs;
    [Space]
    [SerializeField] private Grid grid;
    [Space]
    [SerializeField] private TextMeshProUGUI mainGoalText;

    private string _textPattern = "Find ";
    private Animator _textAnimator;
    private List<Vector3> _availablePositions = new List<Vector3>();
    private void OnEnable()
    {
        ClickableObject.Reached += ChangeLvl;
    }

    private void Start()
    {
        _textAnimator = mainGoalText.gameObject.GetComponent<Animator>();
        _textAnimator.SetBool("NewLvl", true);

        mainGoalText.text = _textPattern + CurrentLetter;

        FillAvailablePositions();
        PlaceObjectsOnGrid();
    }

    private void FillAvailablePositions()
    {
        for (int x = 0; x < grid.columns; x++)
        {
            for (int z = 0; z < grid.rows; z++)
            {
                Vector3 cellPosition = grid.transform.position + new Vector3(x * grid.cellSize, z * grid.cellSize, 0f);
                _availablePositions.Add(cellPosition);
            }
        }
    }

    private void PlaceObjectsOnGrid()
    {
        int objectsToPlace = Mathf.Min(_availablePositions.Count, objectPrefabs.Length);

        for (int i = 0; i < objectsToPlace; i++)
        {
            int randomIndex = Random.Range(0, _availablePositions.Count);
            Vector3 randomPosition = _availablePositions[randomIndex];

            GameObject prefabToPlace = objectPrefabs[i];

            var newLetter = Instantiate(prefabToPlace, randomPosition, Quaternion.identity);
            newLetter.name = objectPrefabs[i].name;
            newLetter.transform.SetParent(transform);

            _availablePositions.RemoveAt(randomIndex);
        }
    }

    private void ChangeLvl(int obj)
    {
        gameObject.SetActive(false);
        nextLvl.SetActive(true);
    }

    private void OnDisable()
    {
        ClickableObject.Reached -= ChangeLvl;
    }
}
