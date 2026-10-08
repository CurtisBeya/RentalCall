using Azure.AI.OpenAI;
using OpenAI;
using OpenAI.Chat;
using RentalCall.Services.Summarization.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCall.Services
{
    public class SummarizationService
    {
        private readonly OpenAIClient _client;

        public SummarizationService(OpenAIClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Takes a transcript and returns a structured summary and action items.
        /// </summary>
        public async Task<SummarizationResult> Summarize(string transcript)
        {
            var prompt = BuildPrompt(transcript);

            var chatClient = _client.GetChatClient("gpt-4");

            var response = await chatClient.CompleteChatAsync(
            [
                new SystemChatMessage(
                    "You are a summarization assistant that summarizes customer service calls " +
                    "and extracts clear, actionable tasks."
                ),
                new UserChatMessage(prompt)
            ]);

            var content = response.Value.Content[0].Text;

            return ParseResponse(content);
        }

        /// <summary>
        /// Builds the prompt used to summarize the transcript and extract action items.
        /// </summary>
        private string BuildPrompt(string transcript)
        {
            return $"""
                Here is a transcript of a multi-speaker customer service conversation.

                Transcript:
                {transcript}

                Your tasks:

                1. Provide a concise Summary of the conversation in 3–5 sentences.
                2. Extract ALL clear and actionable tasks that need to be completed.
                3. Identify the responsible party when it is clear from the conversation.
                5. The number of action items may be zero, one, or many.
                6. If there are no action items, write "- None".

                Output exactly in the following format:

                Summary:
                [summary here]

                Action Items:
                - [action item 1]
                - [action item 2]
                - [action item 3]
                """;
        }

        /// <summary>
        /// Parses the model response into a structured result.
        /// </summary>
        private SummarizationResult ParseResponse(string responseText)
        {
            var result = new SummarizationResult();

            const string summaryHeader = "Summary:";
            const string actionItemsHeader = "Action Items:";

            var summaryIndex = responseText.IndexOf(
                summaryHeader,
                StringComparison.OrdinalIgnoreCase);

            var actionItemsIndex = responseText.IndexOf(
                actionItemsHeader,
                StringComparison.OrdinalIgnoreCase);

            if (summaryIndex == -1 || actionItemsIndex == -1)
            {
                throw new InvalidOperationException(
                    "The AI response did not contain the expected Summary and Action Items sections.");
            }

            // Extract summary
            result.Summary = responseText
                .Substring(
                    summaryIndex + summaryHeader.Length,
                    actionItemsIndex - (summaryIndex + summaryHeader.Length))
                .Trim();

            // Extract action items
            var actionItemsText = responseText
                .Substring(actionItemsIndex + actionItemsHeader.Length)
                .Trim();

            if (actionItemsText.Equals("- None", StringComparison.OrdinalIgnoreCase))
            {
                result.ActionItems = Array.Empty<string>();
            }
            else
            {
                result.ActionItems = actionItemsText
                    .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => line.Trim())
                    .Where(line => line.StartsWith("-"))
                    .Select(line => line.TrimStart('-', ' ').Trim())
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .ToArray();
            }

            return result;
        }
    }
}