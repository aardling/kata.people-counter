namespace Domain
{
    public record CurrentCount(int InAmount, int OutAmount)
    {
        public CurrentCount Add(CurrentCount other)
        {
            return new CurrentCount(this.InAmount + other.InAmount, this.OutAmount + other.OutAmount);
        }
    }
}