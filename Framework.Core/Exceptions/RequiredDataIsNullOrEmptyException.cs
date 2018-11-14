namespace Framework.Core.Exceptions
{
    public class RequiredDataIsNullOrEmptyException : BusinessException

    {
        public RequiredDataIsNullOrEmptyException() : base("700", "اطلاعات فرم به درستی پر نشده است. لطفا دوباره تلاش کنید")
        {
        }
    }
}
