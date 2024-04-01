namespace BackEnd.Domain.Entities;

public class EntityValidator : Exception
{
    public EntityValidator(string error) : base(error)
    { }

    public static void Validate(bool hasError, string error)
    {
        if (hasError)
            throw new EntityValidator(error);
    }
}




