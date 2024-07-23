namespace ems_backend.Models.ResponseModels
{
    public class DataResultCode
    {
        public bool Success { get; set; }
        public string Result { get; set; }
        public string Time { get; set; }
        public string Exception { get; set; }
    }
}
