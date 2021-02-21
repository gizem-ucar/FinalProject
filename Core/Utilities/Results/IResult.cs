using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; } //Başarılı mı başarısız mı?
        string Message { get; } //Yapmaya çalıştığın işlem başarılı mesajı gibi.
    }
}
