namespace schedule_aplication.CustomResponse
{
    public class AuthResponse
    {

        public string Token { get; set; }
        public DateTime DateExpiration { get; set; }
        public int StatusCode { get; set; }
    }
}
