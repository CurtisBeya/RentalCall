namespace AudioSummarizer.Enums
{
    internal enum CallCategoryEnum
    {
        Reservations,
        Billings,
        Claims,
        Maintenance,
        Other
    }

    internal static class CallCategoryExtensions
    {
        public static CallCategoryEnum GetCallCategoryEnumFromString(this String CallCategory)
        {
            if (Enum.TryParse<CallCategoryEnum>(CallCategory.Trim(), true, out var result))
                return result;

            throw new ArgumentException($"Invalid status: {CallCategory}");
        }
    }
}
