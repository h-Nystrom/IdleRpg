  using UnityEngine;

  namespace Clicker.ResourceProduction {
      [CreateAssetMenu (menuName = "Clicker/ResourceProduction/Data", fileName = "ResourceProductionData")] // "ResourceProductionData"
      public class Data : ScriptableObject {
          [SerializeField] int costs = 100;
          public ResourcesIdleClicker.Resource costsResource;
          [SerializeField] float costMultiplier = 1.1f;
          public float productionTime = 1f;
          [SerializeField] int productionAmount = 1;
          public ResourcesIdleClicker.Resource productionResource;
          [SerializeField] float productionMultiplier = 1.05f;

          public int GetActualCosts (int amount) {
              var result = this.costs * Mathf.Pow (this.costMultiplier, amount);
              return Mathf.RoundToInt (result);
          }

          public int GetProductionAmount (int upgradeAmount) {
              var result = this.productionAmount * Mathf.Pow (this.productionMultiplier, upgradeAmount);
              return Mathf.RoundToInt (result);
          }
      }
  }