namespace ReactAPI.Models.Interfaces
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponse> GenerateTokenAsync(GenerateTokenRequest request);
    }
}
