namespace Clicker.Resources {
    [System.Serializable]
    public struct ResourceAmount {
        public Resource resource;
        public int amount;

        public override string ToString () {
            return $"{amount} {resource.name}";
        }
        public bool IsAffordable => this.resource.Amount >= amount;
        public void Create () {
            this.resource.Amount += amount;
        }
        public void Consume () {
            this.resource.Amount -= amount;
        }
    }
}