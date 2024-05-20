using TMPro;
using UnityEngine;

public class FuelIndicatorText : MonoBehaviour
{
    private void Start()
    {
        _indicatorText.text = "";
    }
    [SerializeField] private TextMeshProUGUI _indicatorText;
    private void OnTriggerEnter(Collider other)
    {
        _indicatorText.text = "Refilling...";
    }
    private void OnTriggerExit(Collider other)
    {
        _indicatorText.text = "";
    }
}
