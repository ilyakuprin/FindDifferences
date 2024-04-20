using _FindDifferences.Scripts.Timer;
using UnityEngine;
using UnityEngine.Purchasing;
using Zenject;

public class ReceivingPurchase : MonoBehaviour
{
    private const float TimeInSec = 10f;
    
    [Inject] private readonly TimeCounter _timeCounter; 
    
    public void OnPurchaseCompleted(Product product)
    {
        switch(product.definition.id)
        {
            case "time":
                _timeCounter.AddTime(TimeInSec);
                break;
        }
    }
}
