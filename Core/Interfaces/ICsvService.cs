namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface ICsvService
    {
        string ObjectToCsvData(object obj);

        string ObjectToHeader(object obj);
    }
}