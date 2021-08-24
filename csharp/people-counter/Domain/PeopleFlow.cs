namespace Domain
{
    public record PeopleFlow(int InAmount, int OutAmount)
    {
        public PeopleFlow Add(PeopleFlow other)
        {
            return new PeopleFlow(this.InAmount + other.InAmount, this.OutAmount + other.OutAmount);
        }

        public int Total => InAmount - OutAmount;
    }
}