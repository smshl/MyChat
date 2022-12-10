namespace MyChat.Application.ViewModels
{
    public class DataViewModel
    {
        public string Message { get; set; }
        public bool Succeded { get; set; }
    }
    public class DataViewModel<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Succeded { get; set; }
    }
}
