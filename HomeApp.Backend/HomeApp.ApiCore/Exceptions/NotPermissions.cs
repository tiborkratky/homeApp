using System;

namespace HomeApp.ApiCore.Exceptions
{
    public class NotPermissions : Exception
    {
        public NotPermissions(string message = "You do not have permissions for that!")
            : base(message)
        { }
    }
}
