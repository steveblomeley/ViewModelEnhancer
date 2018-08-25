namespace ViewModelEnhancer.Services.AugmentableInterfaces
{
    public interface IAugmentWithDescription
    {
        int Id { get; }
        string Description { get; set; }
    }
}