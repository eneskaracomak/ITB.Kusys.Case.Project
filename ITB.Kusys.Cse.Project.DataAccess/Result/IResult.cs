namespace ITB.Kusys.Cse.Project.DataAccess.Result
{
    public interface IResult<T>
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        T Data { get; set; }
    }
}
