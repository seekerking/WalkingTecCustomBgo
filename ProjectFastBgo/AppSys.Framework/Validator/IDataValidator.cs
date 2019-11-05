namespace AppSys.Framework.Validator
{
    public interface IDataValidator
    {
        bool Verify(object value);
        bool Verify(string value);
    }
}
