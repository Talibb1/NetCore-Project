
namespace ServiceEntityLayer.Message
{
    public class FluentMessage
    {
        public static string NullEmptyMessage(string PropertyName)
        {
            return $"{PropertyName} is required";
        }   
    }
}
