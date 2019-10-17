using System;

namespace ProjectSIP.Exceptions
{
    public class CantSaveDatabaseException : Exception
    {
        public override string Message => "Невозможно сохранить в базу данных";
    }
}
