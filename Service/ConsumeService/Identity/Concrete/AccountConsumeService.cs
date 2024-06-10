using BaseLayer.Model;
using Entities.ViewModel.AccountVM;
using Newtonsoft.Json;
using Service.ConsumeService.Identity.Abstract;
using System.Text;


namespace Service.ConsumeService.Identity.Concrete
{
    public class AccountConsumeService : IAccountConsumeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;

        public AccountConsumeService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient();
            _url = "https://localhost:7051/api/Account/";
        }

        public AuthResultApiModel Login(LoginVM request)
        {

            AuthResultApiModel model = new AuthResultApiModel();

            var obj = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            var result = _httpClient.PostAsync(_url + "Login", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var response = result.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<AuthResultApiModel>(response);

                model.Error = data.Error;
                model.Message = data.Message;
            }
            return model;



        }
        public AuthResultApiModel Signup(SignUpVM request)
        {
            request.Id = Guid.NewGuid().ToString();
            request.Status = "False";
            AuthResultApiModel model = new AuthResultApiModel();

            var obj = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            var result = _httpClient.PostAsync(_url + "Signup", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var response = result.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<AuthResultApiModel>(response);

                model.Error = data!.Error;
                model.Message = data.Message;
                model.Token = data.Token;
            }
            return model;



        }

        public AuthResultApiModel ForgetPassword(ForgetPasswordVM request)
        {

            AuthResultApiModel model = new AuthResultApiModel();

            var obj = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            var result = _httpClient.PostAsync(_url + "ForgetPassword", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var response = result.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<AuthResultApiModel>(response);

                model.Error = data!.Error;
                model.Message = data.Message;
            }
            return model;



        }



        public AuthResultApiModel ResetPasswordAsync(ResetPasswordVM request)
        {

            AuthResultApiModel model = new AuthResultApiModel();

            var obj = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            var result = _httpClient.PostAsync(_url + "ResetPasswordAsync", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var response = result.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<AuthResultApiModel>(response);

                model.Error = data!.Error;
                model.Message = data.Message;
            }
            return model;



        }
        public AuthResultApiModel LogOutAsync(ResetPasswordVM request)
        {

            AuthResultApiModel model = new AuthResultApiModel();

            var obj = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            var result = _httpClient.PostAsync(_url + "LogOutAsync", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var response = result.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<AuthResultApiModel>(response);

                model.Error = data!.Error;
                model.Message = data.Message;
            }
            return model;



        }


    }
}
