using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class ClickableObject : MonoBehaviour
{
    private string _goal;
    private void Awake()
    {
        var placer = GameObject.FindGameObjectWithTag("ObjectPlacer");
        _goal = placer.GetComponent<ObjectPlacer>().CurrentLetter.ToString();
    }
    private void OnMouseDown()
    {
        if (gameObject.name.Equals(_goal))
        {
            Debug.Log("Object " + gameObject.name + " was pressed!");
        }
    }

}
