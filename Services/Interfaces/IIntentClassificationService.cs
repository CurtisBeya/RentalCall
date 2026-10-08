using RentalCall.Enums;

namespace RentalCall.Services.Interfaces
{
    public interface IIntentClassificationService
    {
        Task<String> Classify(string callSummary);
    }
}
