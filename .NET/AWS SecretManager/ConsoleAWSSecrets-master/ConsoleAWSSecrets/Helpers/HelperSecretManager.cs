using Amazon.SecretsManager.Model;
using Amazon.SecretsManager;
using Amazon;

namespace ConsoleAWSSecrets.Helpers
{
    public class HelperSecretManager
    {
        public async static Task<string> GetSecret()
        {
            string secretName = "datasecrets";
            string region = "us-east-1";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT",
            };

            GetSecretValueResponse response;

            try
            {
                response = await client.GetSecretValueAsync(request);
            }
            catch (Exception e)
            {
                // For a list of the exceptions thrown, see
                // https://docs.aws.amazon.com/secretsmanager/latest/apireference/API_GetSecretValue.html
                throw e;
            }
            string secret = response.SecretString;
            return secret;
        }
    }
}
