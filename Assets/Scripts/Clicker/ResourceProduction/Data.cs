  using Clicker.Resources;
  using UnityEngine;
  namespace Clicker.ResourceProduction {
      [CreateAssetMenu (menuName = "Clicker/ResourceProduction/Data", fileName = "ResourceProductionData")] // "ResourceProductionData"
      public class Data : ScriptableObject {

          public float productionTime = 1f;
          [SerializeField] ResourceAmount costs;
          [Range (1f, 2f)]
          [SerializeField] float costMultiplier = 1.1f;
          [SerializeField] ResourceAmount production;
          [Range (1f, 2f)]
          [SerializeField] float productionMultiplier = 1.05f;

          public ResourceAmount GetActualCosts (int amount) {
              ResourceAmount result = this.costs;
              result.amount = Mathf.RoundToInt (this.costs.amount * Mathf.Pow (this.costMultiplier, amount));
              return result;
          }
          public ResourceAmount GetProductionAmount (int upgradeAmount, int unitCount) {
              ResourceAmount result = this.production;
              result.amount = Mathf.RoundToInt (production.amount * Mathf.Pow (this.productionMultiplier, upgradeAmount) * unitCount);
              return result;
          }
      }
  }