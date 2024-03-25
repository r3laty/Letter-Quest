using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform letterWindow;
    [Space]
    [SerializeField] private Sprite[] sprites;
    [Header("Goal")]
    [SerializeField] private TextMeshProUGUI mainGoalText;
    [SerializeField] private string textPattern = "Find ";

    private int _numberOfLetters => sprites.Length;
    private void Start()
    {
        mainGoalText.text = textPattern;

        CreateLetter(_numberOfLetters);
    }
    private void CreateLetter(int numberOfLetters)
    {
        for (int i = 0; i < numberOfLetters; i++)
        {
            Vector2 newSize = new Vector2(2, 2);

            Image substrate = new GameObject("Substrate").AddComponent<Image>();
            substrate.rectTransform.sizeDelta = newSize + Vector2.one;
            substrate.color = Color.black;
            substrate.transform.SetParent(letterWindow.transform);

            Image newLetter = new GameObject("Letter").AddComponent<Image>();
            newLetter.sprite = sprites[i];
            newLetter.rectTransform.sizeDelta = newSize;
            newLetter.transform.SetParent(substrate.transform); 
        }
    }
}
