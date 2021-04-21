#region Using derectives

using System;

#endregion

namespace Systems.Extensions
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}