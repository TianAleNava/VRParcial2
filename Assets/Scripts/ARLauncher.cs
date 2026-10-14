using NUnit.Framework.Constraints;
using System;
using System.Text.Json.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARLauncher : MonoBehaviour
{
    [SerializeField] private SceneSelector sceneSelector;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<NumberPOI>(out NumberPOI numero) ||
            other.transform.parent != null &&
            other.transform.parent.TryGetComponent<NumberPOI>(out numero))
        {
            sceneSelector.SetScene(numero.sceneNumber);
        }
        else
        {
            Debug.Log("no tiene el componente");
            Debug.Log($"POI colisionado: {other.gameObject.name}");
        }
    }
}