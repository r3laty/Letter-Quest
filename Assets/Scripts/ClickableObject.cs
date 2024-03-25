using System;
using System.Collections;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D), (typeof(ParticleSystem)))]
public class ClickableObject : MonoBehaviour
{
    public static Action<int> Reached;

    [SerializeField] private int howMuchToRaise = 1;

    private string _goal;

    private ParticleSystem _particleSystem;
    private float _particleSystemDuration = 0.8f;
    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();

        var placer = GameObject.FindGameObjectWithTag("ObjectPlacer");
        _goal = placer.GetComponent<ObjectPlacer>().CurrentLetter.ToString();
    }
    private void OnMouseDown()
    {
        if (gameObject.name.Equals(_goal))
        {
            _particleSystem.Play();
            StartCoroutine(DestroyObjectAfterParticles());
        }
        else
        {
            Debug.Log("Nope");
        }
    }
    private IEnumerator DestroyObjectAfterParticles()
    {
        yield return new WaitForSeconds(_particleSystemDuration);
        Destroy(gameObject);
        Reached?.Invoke(howMuchToRaise);
    }

}
