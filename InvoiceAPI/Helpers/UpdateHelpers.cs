namespace InvoiceAPI.Helpers
{
    public static class UpdateHelpers
    {
        public static string UpdateIfNotNullorEmpty(string newValue, string currentValue)
        {
            return string.IsNullOrWhiteSpace(newValue) ? currentValue : newValue;
        }

        public static T UpdateIfNotNull<T>(T newValue, T currentValue)
        {
            return newValue != null ? newValue : currentValue;
        }
    }
}
