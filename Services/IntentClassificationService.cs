using Azure.AI.OpenAI;
using OpenAI;
using OpenAI.Chat;
using RentalCall.Enums;
using RentalCall.Services.Interfaces;

namespace RentalCall.Services
{
    public class IntentClassificationService : IIntentClassificationService
    {
        private readonly AzureOpenAIClient _client;

        public IntentClassificationService(AzureOpenAIClient client)
        {
            _client = client;
        }

        public async Task<String> Classify(string callSummary)
        {
            var chatClient = _client.GetChatClient("gpt-4");

            var prompt = $"""
                   Categorize the following customer service call summary into exactly one of these categories:
                   - Reservations
                   - Billings
                   - Claims
                   - Maintenance
                   - Other

                   Summary:
                   {callSummary}

                   Respond ONLY with the category name.
                   """;

            var response = await chatClient.CompleteChatAsync(
            [
                new SystemChatMessage(
                     "You are a precise customer service call classification assistant. " +
                     "You must return exactly one category from the provided list."
                ),
                new UserChatMessage(prompt)
            ]);

            var categoryText = response.Value.Content[0].Text.Trim();

            //CallCategoryEnum callCategoryEnum = Enum.Parse<CallCategoryEnum>(categoryText, ignoreCase: true);

            return categoryText;
   
        }
    }
}
