using System;

namespace ProjectSIP.Exceptions
{
    public class CantFindUserException : Exception
    {
        public override string Message => "Невозможно найти пользователя";
    }
}
