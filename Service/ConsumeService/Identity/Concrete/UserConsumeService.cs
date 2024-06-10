using Entities.ViewModel.Identity.UserVM;
using Entities.ViewModel.PagerVM;
using Newtonsoft.Json;
using Service.ConsumeService.Identity.Abstract;
using System.Text;


namespace Service.ConsumeService.Identity.Concrete
{
    public class UserConsumeService : IUserConsumeService
    {

        private readonly HttpClient _httpClient;
        private readonly string _url;

        public UserConsumeService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _url = "https://localhost:7051/api/User/";
        }
        public PagingVM GetUser(int CurrentPagerCount)
        {
            PagingVM pager = new PagingVM();

            HttpResponseMessage response = _httpClient.GetAsync(_url + "GetUser/" + CurrentPagerCount).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<PagingVM>(result);
                pager = data!;
            }
            return pager;
        }
        public UserAssignRoleVM ShowUserRole(string userId)
        {
            UserAssignRoleVM userRole = new UserAssignRoleVM();
            HttpResponseMessage response = _httpClient.GetAsync(_url + "ShowUserRole/" + userId).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<UserAssignRoleVM>(result);

                userRole.roles = data!.roles;
                userRole.user = data!.user;


            }
            return userRole;
        }

        public bool AssignRoles(UserAssignRoleVM role)
        {

            var content = JsonConvert.SerializeObject(role);
            StringContent response = new StringContent(content, Encoding.UTF8, "application/json");
            var result = _httpClient.PostAsync(_url + "AssignRoles", response).Result;
            if (result.IsSuccessStatusCode) return true;
            else return false;

        }


        public bool AddUser(UserAddVM request)
        {

            var content = JsonConvert.SerializeObject(request);
            StringContent response = new StringContent(content, Encoding.UTF8, "application/json");
            var result = _httpClient.PostAsync(_url + "Add", response).Result;
            if (result.IsSuccessStatusCode) return true;
            else return false;

        }

        public bool UpdateUser(UserUpdateVM request)
        {

            var content = JsonConvert.SerializeObject(request);
            StringContent response = new StringContent(content, Encoding.UTF8, "application/json");
            var result = _httpClient.PutAsync(_url + "Update", response).Result;
            if (result.IsSuccessStatusCode) return true;
            else return false;

        }

        public UserUpdateVM GetUserById(string userId)
        {
            UserUpdateVM user = new UserUpdateVM();
            HttpResponseMessage response = _httpClient.GetAsync(_url + "GetUserById/" + userId).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<UserUpdateVM>(result);
                user = data;
            }
            return user;
        }

    }
}
